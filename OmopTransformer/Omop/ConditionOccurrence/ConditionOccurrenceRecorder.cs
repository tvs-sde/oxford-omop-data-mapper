using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.ConditionOccurrence;

internal class ConditionOccurrenceRecorder : IConditionOccurrenceRecorder
{
    private readonly Configuration _configuration;

    public ConditionOccurrenceRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateConditionOccurrence<T>(IReadOnlyCollection<OmopConditionOccurrence<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.condition_occurrence_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "condition_occurrence_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        foreach (var conceptId in row.condition_concept_id!)
                        {
                            var dbRow = appender.CreateRow();

                            dbRow
                                .AppendValue(row.nhs_number)
                                .AppendValue(row.RecordConnectionIdentifier)
                                .AppendValue(conceptId)
                                .AppendValue(row.condition_start_date)
                                .AppendValue(row.condition_start_datetime)
                                .AppendValue(row.condition_end_date)
                                .AppendValue(row.condition_end_datetime)
                                .AppendValue(row.condition_type_concept_id)
                                .AppendValue(row.condition_status_concept_id)
                                .AppendValue(row.stop_reason)
                                .AppendValue(row.provider_id)
                                .AppendValue(row.visit_occurrence_id)
                                .AppendValue(row.visit_detail_id)
                                .AppendValue(row.condition_source_value)
                                .AppendValue(row.condition_source_concept_id)
                                .AppendValue(row.condition_status_source_value)
                                .AppendValue(dataSource)
                                .EndRow();
                        }
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


insert into cdm.condition_occurrence (
    person_id,
    condition_concept_id,
    condition_start_date,
    condition_start_datetime,
    condition_end_date,
    condition_end_datetime,
    condition_type_concept_id,
    condition_status_concept_id,
    stop_reason,
    provider_id,
    visit_occurrence_id,
    visit_detail_id,
    condition_source_value,
    condition_source_concept_id,
    condition_status_source_value,
    RecordConnectionIdentifier,
    data_source
)
select
    distinct
        p.person_id,
        r.condition_concept_id,
        r.condition_start_date,
        r.condition_start_datetime,
        r.condition_end_date,
        r.condition_end_datetime,
        r.condition_type_concept_id,
        r.condition_status_concept_id,
        r.stop_reason,
        r.provider_id,
        r.visit_occurrence_id,
        r.visit_detail_id,
        r.condition_source_value,
        r.condition_source_concept_id,
        r.condition_status_source_value,
        r.RecordConnectionIdentifier,
        r.data_source
from omop_staging.condition_occurrence_row r
inner join cdm.person p on r.nhs_number = p.person_source_value
where not exists (
    select 1 
    from cdm.condition_occurrence co 
    where r.RecordConnectionIdentifier is not null
        and co.person_id = p.person_id
        and co.RecordConnectionIdentifier = r.RecordConnectionIdentifier
        and co.condition_concept_id = r.condition_concept_id
        and (co.condition_concept_id != 0 or co.condition_source_value = r.condition_source_value)
)
and not exists (
    select 1 
    from cdm.condition_occurrence co 
    where r.RecordConnectionIdentifier is null
        and co.condition_concept_id = r.condition_concept_id
        and co.condition_start_date = r.condition_start_date
        and co.person_id = p.person_id
        and (co.condition_concept_id != 0 or co.condition_source_value = r.condition_source_value)
);
 

truncate table omop_staging.condition_occurrence_row;",
                cancellationToken);
    }
}