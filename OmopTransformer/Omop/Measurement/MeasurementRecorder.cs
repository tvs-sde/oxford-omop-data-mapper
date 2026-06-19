using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.Measurement;

internal class MeasurementRecorder : IMeasurementRecorder
{
    private readonly Configuration _configuration;

    public MeasurementRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateMeasurements<T>(IReadOnlyCollection<OmopMeasurement<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.measurement_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "measurement_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        foreach (var conceptId in row.measurement_concept_id!)
                        {
                            var dbRow = appender.CreateRow();

                            dbRow
                                .AppendValue(row.nhs_number)
                                .AppendValue(conceptId)
                                .AppendValue(row.measurement_date)
                                .AppendValue(row.measurement_datetime)
                                .AppendValue(row.measurement_time)
                                .AppendValue(row.measurement_type_concept_id)
                                .AppendValue(row.operator_concept_id)
                                .AppendValue((float?)row.value_as_number)
                                .AppendValue(row.value_as_concept_id)
                                .AppendValue(row.unit_concept_id)
                                .AppendValue((float?)row.range_low)
                                .AppendValue((float?)row.range_high)
                                .AppendValue(row.provider_id)
                                .AppendValue(row.measurement_source_value)
                                .AppendValue(row.measurement_source_concept_id)
                                .AppendValue(row.unit_source_value)
                                .AppendValue(row.unit_source_concept_id)
                                .AppendValue(row.value_source_value)
                                .AppendValue(row.measurement_event_id)
                                .AppendValue(row.meas_event_field_concept_id)
                                .AppendValue(row.RecordConnectionIdentifier)
                                .AppendValue(row.HospitalProviderSpellNumber)
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


insert into cdm.measurement (
    person_id,
    measurement_concept_id,
    measurement_date,
    measurement_datetime,
    measurement_time,
    measurement_type_concept_id,
    operator_concept_id,
    value_as_number,
    value_as_concept_id,
    unit_concept_id,
    range_low,
    range_high,
    provider_id,
    measurement_source_value,
    measurement_source_concept_id,
    unit_source_value,
    unit_source_concept_id,
    value_source_value,
    measurement_event_id,
    meas_event_field_concept_id,
    RecordConnectionIdentifier,
    HospitalProviderSpellNumber,
    data_source
)
select
    distinct
        p.person_id,
        r.measurement_concept_id,
        r.measurement_date,
        r.measurement_datetime,
        r.measurement_time,
        r.measurement_type_concept_id,
        r.operator_concept_id,
        r.value_as_number,
        r.value_as_concept_id,
        r.unit_concept_id,
        r.range_low,
        r.range_high,
        r.provider_id,
        r.measurement_source_value,
        r.measurement_source_concept_id,
        r.unit_source_value,
        r.unit_source_concept_id,
        r.value_source_value,
        r.measurement_event_id,
        r.meas_event_field_concept_id,
        r.RecordConnectionIdentifier,
        r.HospitalProviderSpellNumber,
        r.data_source
from omop_staging.measurement_row r
    inner join cdm.person p
        on r.nhs_number = p.person_source_value
where 
    not exists (
        select 1
        from cdm.measurement m
        where m.person_id = p.person_id 
            and m.measurement_date = r.measurement_date
            and m.measurement_concept_id = r.measurement_concept_id
            and (r.measurement_source_concept_id is null or m.measurement_source_concept_id = r.measurement_source_concept_id)
            and r.RecordConnectionIdentifier is null
            and r.HospitalProviderSpellNumber is null
            and (m.measurement_concept_id != 0 or ((m.value_source_value is null and r.value_source_value is null) or m.value_source_value = r.value_source_value))
    )
    and not exists (
        select 1
        from cdm.measurement m
        where m.person_id = p.person_id 
            and m.measurement_date = r.measurement_date
            and m.measurement_concept_id = r.measurement_concept_id
            and (r.measurement_source_concept_id is null or m.measurement_source_concept_id = r.measurement_source_concept_id)
            and r.RecordConnectionIdentifier is not null
            and m.RecordConnectionIdentifier = r.RecordConnectionIdentifier
            and (m.measurement_concept_id != 0 or ((m.value_source_value is null and r.value_source_value is null) or m.value_source_value = r.value_source_value))
    )
    and not exists (
        select 1
        from cdm.measurement m
        where m.person_id = p.person_id 
            and m.measurement_date = r.measurement_date
            and m.measurement_concept_id = r.measurement_concept_id
            and (r.measurement_source_concept_id is null or m.measurement_source_concept_id = r.measurement_source_concept_id)
            and r.HospitalProviderSpellNumber is not null
            and m.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber
            and (m.measurement_concept_id != 0 or ((m.value_source_value is null and r.value_source_value is null) or m.value_source_value = r.value_source_value))
    );

truncate table omop_staging.measurement_row;",
                cancellationToken);

    }
}