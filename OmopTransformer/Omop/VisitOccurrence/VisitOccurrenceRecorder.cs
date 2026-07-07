using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.VisitOccurrence;

internal class VisitOccurrenceRecorder : IVisitOccurrenceRecorder
{
    private readonly Configuration _configuration;

    public VisitOccurrenceRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateVisitOccurrence<T>(IReadOnlyCollection<OmopVisitOccurrence<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.visit_occurrence_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "visit_occurrence_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        var dbRow = appender.CreateRow();

                        dbRow
                            .AppendValue(row.NhsNumber)
                            .AppendValue(row.HospitalProviderSpellNumber)
                            .AppendValue(row.RecordConnectionIdentifier)
                            .AppendValue(row.visit_concept_id)
                            .AppendValue(row.visit_start_date)
                            .AppendValue(row.visit_start_datetime)
                            .AppendValue(row.visit_end_date)
                            .AppendValue(row.visit_end_datetime)
                            .AppendValue(row.visit_type_concept_id)
                            .AppendValue(row.provider_id)
                            .AppendValue(row.care_site_id)
                            .AppendValue(row.visit_source_value)
                            .AppendValue(row.visit_source_concept_id)
                            .AppendValue(row.admitted_from_concept_id)
                            .AppendValue(row.admitted_from_source_value)
                            .AppendValue(row.discharged_to_concept_id)
                            .AppendValue(row.discharged_to_source_value)
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

insert into cdm.visit_occurrence (
    person_id,
    visit_concept_id,
    visit_start_date,
    visit_start_datetime,
    visit_end_date,
    visit_end_datetime,
    visit_type_concept_id,
    provider_id,
    care_site_id,
    visit_source_value,
    visit_source_concept_id,
    admitted_from_concept_id,
    admitted_from_source_value,
    discharged_to_concept_id,
    discharged_to_source_value,
    hospitalproviderspellnumber,
    recordconnectionidentifier,
    data_source
)
select 
    distinct
        p.person_id,
        r.visit_concept_id,
        r.visit_start_date,
        r.visit_start_datetime,
        r.visit_end_date,
        r.visit_end_datetime,
        r.visit_type_concept_id,
        r.provider_id,
        r.care_site_id,
        r.visit_source_value,
        r.visit_source_concept_id,
        r.admitted_from_concept_id,
        r.admitted_from_source_value,
        r.discharged_to_concept_id,
        r.discharged_to_source_value,
        r.hospitalproviderspellnumber,
        r.recordconnectionidentifier,
        r.data_source
from omop_staging.visit_occurrence_row r
inner join cdm.person p on r.nhs_number = p.person_source_value
where 
    (
        r.recordconnectionidentifier is not null 
        and not exists (
            select 1
            from cdm.visit_occurrence vo
            where vo.recordconnectionidentifier = r.recordconnectionidentifier
                and vo.person_id = p.person_id
        )
    )
    or
    (
        r.hospitalproviderspellnumber is not null 
        and not exists (
            select 1
            from cdm.visit_occurrence vo
            where vo.hospitalproviderspellnumber = r.hospitalproviderspellnumber
                and vo.person_id = p.person_id
        )
    )
    or
    (
        r.hospitalproviderspellnumber is null
        and r.recordconnectionidentifier is null
        and not exists (
            select 1
            from cdm.visit_occurrence vo
            where vo.person_id = p.person_id
                and vo.visit_start_date = r.visit_start_date
        )
    );


truncate table omop_staging.visit_occurrence_row;
",
                cancellationToken);
    }
}