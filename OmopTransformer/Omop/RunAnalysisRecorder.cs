using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop;

internal class RunAnalysisRecorder : IRunAnalysisRecorder
{
    private readonly Configuration _configuration;

    public RunAnalysisRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public void InsertRunAnalysis(Guid runId, string tableType, string origin, int validCount, int invalidCount)
    {
        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        connection.Open();

        using var appender = connection.CreateAppender("dbo", "run_analysis");
        {
           
            var dbRow = appender.CreateRow();

            dbRow
                .AppendValue(runId)
                .AppendValue(DateTime.Now)
                .AppendValue(tableType) 
                .AppendValue(origin) 
                .AppendValue(validCount) 
                .AppendValue(invalidCount)
                .EndRow();
        }
    }
}