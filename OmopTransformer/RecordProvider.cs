using System.Collections.ObjectModel;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OmopTransformer.Annotations;
using OmopTransformer.Transformation;

namespace OmopTransformer;

internal class RecordProvider : IRecordProvider
{
    private readonly Configuration _configuration;
    private readonly IQueryLocator _queryLocator;
    private readonly ILogger<RecordProvider> _logger;
    private readonly TransformOptions _transformOptions;

    public RecordProvider(IOptions<Configuration> configuration, IQueryLocator queryLocator, ILogger<RecordProvider> logger, TransformOptions transformOptions)
    {
        _configuration = configuration.Value;
        _queryLocator = queryLocator;
        _logger = logger;
        _transformOptions = transformOptions;
    }
    
    public async Task<IReadOnlyCollection<T>> GetRecordsBatched<T>(int batchNumber, int batchSize, CancellationToken cancellationToken)
    {
        var query = GetQuery<T>();

        string queryText = query.Sql!.Value!;

        if (query.Sql.Type == "duckdb")
        {
            if (string.IsNullOrEmpty(_transformOptions.DuckdbSource))
                throw new NotSupportedException($"'duckdb-source' argument must be specified when executing a duckdb sql query. Query was '{query.Sql.Value}'.");

            const string dbSourceConstant = "##duckdb_source##";

            if (query.Sql?.Value?.Contains(dbSourceConstant) == false)
                throw new InvalidDataException($"Query of type duckdb must contain the following replacement token '{dbSourceConstant}'. Query was '{query.Sql.Value}'.");

            queryText = queryText.Replace(dbSourceConstant, _transformOptions.DuckdbSource);

            _logger.LogTrace("Duckdb query: {0}", queryText);

            var connection = new DuckDBConnection("Data Source=:memory:");
            await connection.OpenAsync(cancellationToken);

            return await BatchQuery<T>(queryText, batchSize, connection, "duckdb", batchNumber, cancellationToken);

        }

        if (query.Sql!.Type is null or "mssql")
        {
            var connection = new DuckDBConnection(_configuration.ConnectionString!);
            await connection.OpenAsync(cancellationToken);

            return await BatchQuery<T>(queryText, batchSize, connection, "mssql", batchNumber, cancellationToken);
        }

        throw UnsupportedType(query.Sql.Type);
    }
    
    private static NotSupportedException UnsupportedType(string typeName) => throw new NotSupportedException($"Unsupported query type '{typeName}'. Supported options are mssql, duckdb");

    private async Task<IReadOnlyCollection<T>> BatchQuery<T>(
        string queryText, 
        int batchSize,
        DuckDBConnection connection,
        string dialect,
        int batchNumber,
        CancellationToken cancellationToken)
    {
        if (dialect == "duckdb" || ContainsOrderByClause(queryText))
        {
            _logger.LogInformation("Running query. Pagination enabled. Batch size {0}.", batchSize);

            _logger.LogInformation("Batch {0}", batchNumber);

            queryText = queryText.TrimEnd(';', '\n', '\t');

            int offset = batchSize * batchNumber;

            string? batchQuery = dialect switch
            {
                "mssql" => $"{queryText} OFFSET {offset} ROWS FETCH NEXT {batchSize} ROWS ONLY",
                "duckdb" => $"{queryText} LIMIT {batchSize} OFFSET {offset}",
                _ => throw UnsupportedType(dialect)
            };

            return (await connection.QueryAsync<T>(batchQuery, cancellationToken)).ToList().AsReadOnly();
        }

        if (batchNumber == 0)
            return await ExecuteNonBatchedQuery<T>(queryText, cancellationToken, connection);

        // If the caller asks for batch 1 of a non batched query then give them an empty collection.
        return new ReadOnlyCollection<T>(new List<T>());
    }

    private async Task<IReadOnlyCollection<T>> ExecuteNonBatchedQuery<T>(string queryText, CancellationToken cancellationToken, DuckDBConnection connection)
    {
        _logger.LogInformation("Running query. Pagination disabled (order by clause missing).");

        var command = new CommandDefinition(queryText, cancellationToken: cancellationToken);

        var results = await connection.QueryAsync<T>(command);

        return results.ToList().AsReadOnly();
    }

    private Query GetQuery<T>()
    {
        var sourceQuery = (SourceQueryAttribute)typeof(T).GetCustomAttributes(typeof(SourceQueryAttribute), inherit: false).Single();
        return _queryLocator.GetQuery(sourceQuery.QueryFileName); ;
    }

    private static bool ContainsOrderByClause(string query) => query.ToUpperInvariant().Contains("ORDER BY");
}