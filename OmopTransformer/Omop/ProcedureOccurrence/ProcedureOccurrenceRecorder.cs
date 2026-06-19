using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.ProcedureOccurrence;

internal class ProcedureOccurrenceRecorder : IProcedureOccurrenceRecorder
{
    private readonly Configuration _configuration;

    public ProcedureOccurrenceRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateProcedureOccurrence<T>(IReadOnlyCollection<OmopProcedureOccurrence<T>> records, string dataSource, CancellationToken cancellationToken)
    {

        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.procedure_occurrence_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "procedure_occurrence_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        foreach (var conceptId in row.procedure_concept_id!)
                        {
                            var dbRow = appender.CreateRow();

                            dbRow
                                .AppendValue(row.nhs_number)
                                .AppendValue(conceptId)
                                .AppendValue(row.procedure_date)
                                .AppendValue(row.procedure_datetime)
                                .AppendValue(row.procedure_end_date)
                                .AppendValue(row.procedure_end_datetime)
                                .AppendValue(row.procedure_type_concept_id)
                                .AppendValue(row.modifier_concept_id)
                                .AppendValue(row.quantity)
                                .AppendValue(row.provider_id)
                                .AppendValue(row.visit_occurrence_id)
                                .AppendValue(row.visit_detail_id)
                                .AppendValue(row.procedure_source_value)
                                .AppendValue(row.procedure_source_concept_id)
                                .AppendValue(row.modifier_source_value)
                                .AppendValue(row.RecordConnectionIdentifier)
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


insert into cdm.procedure_occurrence (
    person_id,
    procedure_concept_id,
    procedure_date,
    procedure_datetime,
    procedure_end_date,
    procedure_end_datetime,
    procedure_type_concept_id,
    modifier_concept_id,
    quantity,
    provider_id,
    visit_occurrence_id,
    visit_detail_id,
    procedure_source_value,
    procedure_source_concept_id,
    modifier_source_value,
    RecordConnectionIdentifier,
    data_source
)
select
    distinct
        p.person_id,
        r.procedure_concept_id,
        r.procedure_date,
        r.procedure_datetime,
        r.procedure_end_date,
        r.procedure_end_datetime,
        r.procedure_type_concept_id,
        r.modifier_concept_id,
        r.quantity,
        r.provider_id,
        r.visit_occurrence_id,
        r.visit_detail_id,
        r.procedure_source_value,
        r.procedure_source_concept_id,
        r.modifier_source_value,
        r.RecordConnectionIdentifier,
        r.data_source
from omop_staging.procedure_occurrence_row r
inner join cdm.person p
    on r.nhs_number = p.person_source_value
where 
    not exists (
        select 1
        from cdm.procedure_occurrence vo
        where 
            (
                r.RecordConnectionIdentifier is not null and
                vo.RecordConnectionIdentifier = r.RecordConnectionIdentifier and
                vo.person_id = p.person_id and
                vo.procedure_date = r.procedure_date and
                vo.procedure_concept_id = r.procedure_concept_id and     
                (vo.procedure_concept_id != 0 or ((vo.procedure_source_value is null and r.procedure_source_value is null) or vo.procedure_source_value = r.procedure_source_value))

            )
            or
            (
                r.RecordConnectionIdentifier is null and
                vo.procedure_date = r.procedure_date and
                vo.procedure_concept_id = r.procedure_concept_id and
                vo.person_id = p.person_id and
                (vo.procedure_concept_id != 0 or ((vo.procedure_source_value is null and r.procedure_source_value is null) or vo.procedure_source_value = r.procedure_source_value))
            )
    );

truncate table omop_staging.procedure_occurrence_row;",
                    cancellationToken);

    }
}