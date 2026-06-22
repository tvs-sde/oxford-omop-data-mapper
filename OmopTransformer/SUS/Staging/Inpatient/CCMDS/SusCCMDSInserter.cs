using System.Data;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmopTransformer.SUS.Staging.Inpatient.CCMDS;

internal class SusCCMDSInserter : ISusCCMDSInserter
{
    private readonly Configuration _configuration;
    private readonly ILogger<SusCCMDSInserter> _logger;

    public SusCCMDSInserter(IOptions<Configuration> configuration, ILogger<SusCCMDSInserter> logger)
    {
        _logger = logger;
        _configuration = configuration.Value;
    }

    public async Task Insert(IEnumerable<CCMDSRecord> rows, CancellationToken cancellationToken)
    {
        if (rows == null) throw new ArgumentNullException(nameof(rows));

        _logger.LogInformation("Recording SUS rows.");

        var batches = rows.Batch(_configuration.BatchSize!.Value);
        int batchNumber = 1;

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            foreach (var batch in batches)
            {
                _logger.LogInformation("Batch {0}.", batchNumber++);

                InsertBatch(batch, connection, cancellationToken);
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }

    private void InsertBatch(IEnumerable<CCMDSRecord> rows, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var rowsList = rows.ToList();

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting CCMDS.");
        InsertCCMDS(rowsList.Select(row => row.Row).ToList(), connection);
        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting CCMDS CriticalCareActivityCode.");
        InsertCriticalCareActivityCodes(rowsList.SelectMany(row => row.ActivityCodes).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting CCMDS CriticalCareHighCostDrugs.");
        InsertHighCostDrugs(rowsList.SelectMany(row => row.HighCostDrugs).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();
    }

    private void InsertCCMDS(IReadOnlyCollection<CCMDSRow> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_CCMDS");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.GeneratedRecordID)
                    .AppendValue(row.LoadStagingDate)
                    .AppendValue(row.CriticalCarePeriodSequenceNumber)
                    .AppendValue(row.CDSVersionontheepisodes)
                    .AppendValue(row.HESEPITYPEoftheepisode)
                    .AppendValue(row.CDSInterchangeID)
                    .AppendValue(row.HESEPISTAToftheepisode)
                    .AppendValue(row.EventDate)
                    .AppendValue(row.ActivityDateCriticalCare)
                    .AppendValue(row.CriticalCarePeriodType)
                    .AppendValue(row.CriticalCareEpisodeRelationship)
                    .AppendValue(row.CriticalCareUnitFunction)
                    .AppendValue(row.CriticalCareStartDate)
                    .AppendValue(row.CriticalCareStartTime)
                    .AppendValue(row.CriticalCarePeriodDischargeDate)
                    .AppendValue(row.CriticalCarePeriodDischargeTime)
                    .AppendValue(row.CriticalCarePeriodLocalIdentifier)
                    .AppendValue(row.GestationLengthAtDelivery)
                    .AppendValue(row.CriticalCareSequenceNumberDerived)
                    .AppendValue(row.TotalnumberofCriticalCareActivitiesDerived)
                    .AppendValue(row.LastRecordforthisCriticalCarePeriodIndicatorDerived)
                    .AppendValue(row.CriticalCareActivitytoEpisodeRelationshipDerived)
                    .AppendValue(row.PersonWeight)
                    .EndRow();
            }
        }
    }

    private void InsertHighCostDrugs(IReadOnlyCollection<CCMDSCriticalCareHighCostDrugs> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_CCMDS_CriticalCareHighCostDrugs");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.CriticalCareHighCostDrugs)
                    .EndRow();
            }
        }
    }

    private void InsertCriticalCareActivityCodes(IReadOnlyCollection<CCMDSCriticalCareActivityCode> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_CCMDS_CriticalCareActivityCode");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.CriticalCareActivityCode)
                    .EndRow();
            }
        }
    }
}