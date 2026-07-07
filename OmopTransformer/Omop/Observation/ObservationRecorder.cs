using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.Observation;

internal class ObservationRecorder : IObservationRecorder
{
    private readonly Configuration _configuration;

    public ObservationRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateObservations<T>(IReadOnlyCollection<OmopObservation<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.observation_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "observation_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        foreach (var conceptId in row.observation_concept_id!)
                        {
                            var dbRow = appender.CreateRow();

                            dbRow
                                .AppendValue(row.nhs_number)
                                .AppendValue(row.RecordConnectionIdentifier)
                                .AppendValue(row.HospitalProviderSpellNumber)
                                .AppendValue(conceptId)
                                .AppendValue(row.observation_date)
                                .AppendValue(row.observation_datetime)
                                .AppendValue(row.observation_type_concept_id)
                                .AppendValue((float?)row.value_as_number)
                                .AppendValue(row.value_as_string)
                                .AppendValue(row.value_as_concept_id)
                                .AppendValue(row.qualifier_concept_id)
                                .AppendValue(row.unit_concept_id)
                                .AppendValue(row.provider_id)
                                .AppendValue(row.observation_source_value)
                                .AppendValue(row.observation_source_concept_id)
                                .AppendValue(row.unit_source_value)
                                .AppendValue(row.qualifier_source_value)
                                .AppendValue(row.value_source_value)
                                .AppendValue(row.observation_event_id)
                                .AppendValue(row.obs_event_field_concept_id)
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


insert into cdm.observation (
    person_id,
    observation_concept_id,
    observation_date,
    observation_datetime,
    observation_type_concept_id,
    value_as_number,
    value_as_string,
    value_as_concept_id,
    qualifier_concept_id,
    unit_concept_id,
    provider_id,
    visit_occurrence_id,
    visit_detail_id,
    observation_source_value,
    observation_source_concept_id,
    unit_source_value,
    qualifier_source_value,
    value_source_value,
    observation_event_id,
    obs_event_field_concept_id,
    RecordConnectionIdentifier,
    HospitalProviderSpellNumber,
    data_source
)
select
    distinct
        p.person_id,
        r.observation_concept_id,
        r.observation_date,
        r.observation_datetime,
        r.observation_type_concept_id,
        r.value_as_number,
        r.value_as_string,
        r.value_as_concept_id,
        r.qualifier_concept_id,
        r.unit_concept_id,
        r.provider_id,
        (
            select
                vd.visit_occurrence_id
            from cdm.visit_detail vd
            where vd.RecordConnectionIdentifier = r.RecordConnectionIdentifier
                and vd.person_id = p.person_id
            limit 1
        ) as visit_occurrence_id,
        (
            select
                vd.visit_detail_id
            from cdm.visit_detail vd
            where vd.RecordConnectionIdentifier = r.RecordConnectionIdentifier
                and vd.person_id = p.person_id
            limit 1
        ) as visit_detail_id,
        r.observation_source_value,
        r.observation_source_concept_id,
        r.unit_source_value,
        r.qualifier_source_value,
        r.value_source_value,
        r.observation_event_id,
        r.obs_event_field_concept_id,
        r.RecordConnectionIdentifier,
        r.HospitalProviderSpellNumber,
        r.data_source
from omop_staging.observation_row r
inner join cdm.person p
    on r.nhs_number = p.person_source_value
where 
    not exists (
        select 1
        from cdm.observation o
        where 
            (
                r.RecordConnectionIdentifier is not null and
                o.person_id = p.person_id and
                o.observation_date = r.observation_date and
                o.observation_concept_id = r.observation_concept_id and
                o.RecordConnectionIdentifier = r.RecordConnectionIdentifier and
                (r.HospitalProviderSpellNumber is null or o.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber) and
                (r.observation_source_concept_id is null or o.observation_source_concept_id = r.observation_source_concept_id) and
                (o.observation_concept_id != 0 or ((o.value_as_string is null and r.value_as_string is null) or o.value_as_string = r.value_as_string))
            )
            or
            (
                r.RecordConnectionIdentifier is null and
                o.person_id = p.person_id and
                o.observation_date = r.observation_date and
                o.observation_concept_id = r.observation_concept_id and
                o.observation_source_concept_id = r.observation_source_concept_id and
                (o.observation_concept_id != 0 or ((o.value_as_string is null and r.value_as_string is null) or o.value_as_string = r.value_as_string))
            )
    );

truncate table omop_staging.observation_row;",
        cancellationToken);
    }
}