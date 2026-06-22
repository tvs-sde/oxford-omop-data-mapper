using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.Death;

internal class DeathRecorder : IDeathRecorder
{
    private readonly Configuration _configuration;

    public DeathRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateDeaths<T>(IReadOnlyCollection<OmopDeath<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.death_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "death_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        var dbRow = appender.CreateRow();

                        dbRow
                            .AppendValue(row.NhsNumber)
                            .AppendValue(row.death_date)
                            .AppendValue(row.death_datetime)
                            .AppendValue(row.death_type_concept_id)
                            .AppendValue(row.cause_concept_id)
                            .AppendValue(row.cause_source_value)
                            .AppendValue(row.cause_source_concept_id)
                            .AppendValue(dataSource)
                            .EndRow();
                    }
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();

                throw;
            }
        }

        await connection
            .ExecuteAsync(
                @"


insert into cdm.death (
    person_id,
    death_date,
    death_datetime,
    death_type_concept_id,
    cause_concept_id,
    cause_source_value,
    cause_source_concept_id,
    data_source
)
select
    distinct
        p.person_id,
        r.death_date,
        r.death_datetime,
        r.death_type_concept_id,
        r.cause_concept_id,
        r.cause_source_value,
        r.cause_source_concept_id,
        r.data_source
from omop_staging.death_row r
    inner join cdm.person p
        on r.nhs_number = p.person_source_value
where 
    not exists (
        select 1
        from cdm.death d
        where d.person_id = p.person_id
    );

truncate table omop_staging.death_row;",
                cancellationToken);
    }
}