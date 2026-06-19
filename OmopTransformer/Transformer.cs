using System.Diagnostics;
using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Transformation;

namespace OmopTransformer;

internal abstract class Transformer
{
    private readonly IRecordTransformer _recordTransformer;
    private readonly ILogger<IRecordTransformer> _logger;
    private readonly TransformOptions _transformOptions;
    private readonly IRecordProvider _recordProvider;
    private readonly IRunAnalysisRecorder _runAnalysisRecorder;
    private readonly ILoggerFactory _loggerFactory;

    private readonly string _dataSource;

    protected Transformer(IRecordTransformer recordTransformer, TransformOptions transformOptions, IRecordProvider recordProvider, string dataSource, IRunAnalysisRecorder runAnalysisRecorder, ILoggerFactory loggerFactory)
    {
        _recordTransformer = recordTransformer;
        _logger = loggerFactory.CreateLogger<IRecordTransformer>();
        _transformOptions = transformOptions;
        _recordProvider = recordProvider;
        _dataSource = dataSource;
        _runAnalysisRecorder = runAnalysisRecorder;
        _loggerFactory = loggerFactory;
    }

    public async Task Transform<TSource, TTarget>(
        Func<IReadOnlyCollection<TTarget>, string, CancellationToken, Task> insertRecord,
        string name,
        Guid runId,
        CancellationToken cancellationToken)
        where TTarget : IOmopRecord<TSource>, new()
    {
        var overallStopwatch = Stopwatch.StartNew();
        var computeStopwatch = new Stopwatch();
        var getRecordsStopwatch = Stopwatch.StartNew();
        var insertRecordsStopwatch = new Stopwatch();

        var notEndOfRecords = true;
        int batchNumber = 0;

        var stats = new StatsInternal();

        while (notEndOfRecords)
        {
            // This may seem strange pattern, but this is to reduce overall memory consumption and to be fairly aggressive in regards to recovering memory. The aim is to avoid out of memory exceptions.
            // Previously here we were consuming an enumeration of batches of results. As we enumerated the enumerable a new page of results would be lifted from the database and placed in memory, before being mapped to a .net type.
            // The aim there was to avoid having too many records in memory at any given time, to avoid running out memory.

            // However it transpires that the pointer seems to need to leave the method before these .net objects can be released, even if it is the case that you can no longer actually reference these (as they are in an earlier iteration of the foreach loop).
            // It may be the case that the garbage collection service will remove the memory, however there is one more complication - when we read CSVs we use duckdb, which uses unmanaged memory. This is a problem
            // because it seems that duck db can allocate more memory than is available before the GC service has the chance to collect unused objects in cases of high memory pressure, and the application crashes.

            // The fix here is to call a method that 1) lifts a batch of data, 2) processes the data 3) inserts the data and quits and then call the GC service.
            // This seems to work extraordinarily well. We can recover all of the memory very quickly (hundreds of milliseconds), ie from 4GB back to 28MB.
            // One more point to note is that we also request "compacting: true". This is required to avoid memory fragmentation.
            GC.Collect(2, GCCollectionMode.Aggressive, true, true);

            notEndOfRecords = await ProcessBatch<TSource, TTarget>(
                name: name,
                statsInternal: stats,
                computeStopwatch: computeStopwatch,
                getRecordsStopwatch: getRecordsStopwatch,
                insertRecordsStopwatch: insertRecordsStopwatch,
                insertRecord: insertRecord,
                batchNumber: batchNumber++,
                cancellationToken);
        }


        if (_transformOptions.DryRun == false)
        {
            _runAnalysisRecorder
                .InsertRunAnalysis(
                    runId: runId,
                    tableType: _dataSource,
                    origin: $"{typeof(TTarget).Name}:{name}",
                    validCount: stats.ValidRowCount,
                    invalidCount: stats.InvalidRowCount);
        }

        overallStopwatch.Stop();

        string text =
            "--------------------------------" + Environment.NewLine +
            $"Transformation: {name}" + Environment.NewLine +
            $"Valid rows: {stats.ValidRowCount}" + Environment.NewLine +
            $"Invalid rows: {stats.InvalidRowCount}" + Environment.NewLine +
            $"Overall time: {overallStopwatch}. {PerSecond(overallStopwatch, stats.MappedRecordsCount)} per second" + Environment.NewLine +
            $"Read time: {getRecordsStopwatch}. {PerSecond(getRecordsStopwatch, stats.MappedRecordsCount)} per second" + Environment.NewLine +
            $"Write time: {insertRecordsStopwatch}. {PerSecond(insertRecordsStopwatch, stats.ValidRowCount)} per second" + Environment.NewLine +
            $"CPU time : {computeStopwatch}. {PerSecond(computeStopwatch, stats.MappedRecordsCount)} per second" + Environment.NewLine +
            "--------------------------------" + Environment.NewLine;

        _logger.LogInformation(text);

        _recordTransformer.PrintLogsAndResetLogger(_loggerFactory);
    }

    private async Task<bool> ProcessBatch<TSource, TTarget>(
        string name,
        StatsInternal statsInternal,
        Stopwatch computeStopwatch,
        Stopwatch getRecordsStopwatch,
        Stopwatch insertRecordsStopwatch,
        Func<IReadOnlyCollection<TTarget>, string, CancellationToken, Task> insertRecord,
        int batchNumber,
        CancellationToken cancellationToken) 
        where TTarget : IOmopRecord<TSource>, new()
    {
        int batchSize = _transformOptions.BatchSize;

        getRecordsStopwatch.Start();
        
        var records = await _recordProvider.GetRecordsBatched<TSource>(batchNumber, batchSize, cancellationToken);

        getRecordsStopwatch.Stop();
        
        if (records.Any() == false)
            return false;

        var mappedRecords =
            records
                .Select(record => new TTarget { Source = record })
                .ToList();

        computeStopwatch.Start();

        if (mappedRecords.Any())
        {
            var transformPlan = TransformPlan.Create(mappedRecords.First());

            Parallel.ForEach(mappedRecords, record =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                _recordTransformer.Transform(record, transformPlan);
            });
        }

       

        computeStopwatch.Stop();

        insertRecordsStopwatch.Start();

        if (_transformOptions.DryRun == false)
        {
            await insertRecord(mappedRecords, $"{_dataSource}:{name}", cancellationToken);
        }

        statsInternal.ValidRowCount += mappedRecords.Count(r => r.IsValid);
        statsInternal.InvalidRowCount += mappedRecords.Count(r => r.IsValid == false);
        statsInternal.MappedRecordsCount += mappedRecords.Count;

        insertRecordsStopwatch.Stop();

        return records.Count >= batchSize; // If we had fewer results than are requested batch size then this must be the last batch.
    }

    private static string PerSecond(Stopwatch stopwatch, int total)
    {
        const int lowSampleThreshold = 20000;

        if (stopwatch.Elapsed.TotalSeconds == 0 || total < lowSampleThreshold)
            return "n/a";
        
        return ((int)(total / stopwatch.Elapsed.TotalSeconds)).ToString();
    }

    private class StatsInternal
    {
        public int ValidRowCount { get; set; }
        public int InvalidRowCount { get; set; }
        public int MappedRecordsCount { get; set; }
    }
}