using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.DeviceExposure;

internal class DeviceExposureRecorder : IDeviceExposureRecorder
{
    private readonly Configuration _configuration;

    public DeviceExposureRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateDeviceExposure<T>(IReadOnlyCollection<OmopDeviceExposure<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.device_exposure_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "device_exposure_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        foreach (var deviceConceptId in row.device_concept_id!)
                        {

                            var dbRow = appender.CreateRow();

                            dbRow
                                .AppendValue(row.nhs_number)
                                .AppendValue(deviceConceptId)
                                .AppendValue(row.device_exposure_start_date)
                                .AppendValue(row.device_exposure_start_datetime)
                                .AppendValue(row.device_exposure_end_date)
                                .AppendValue(row.device_exposure_end_datetime)
                                .AppendValue(row.device_type_concept_id)
                                .AppendValue(row.unique_device_id)
                                .AppendValue(row.production_id)
                                .AppendValue(row.quantity)
                                .AppendValue(row.provider_id)
                                .AppendValue(row.visit_occurrence_id)
                                .AppendValue(row.visit_detail_id)
                                .AppendValue(row.device_source_value)
                                .AppendValue(row.device_source_concept_id)
                                .AppendValue(row.unit_concept_id)
                                .AppendValue(row.unit_source_value)
                                .AppendValue(row.unit_source_concept_id)
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


insert into cdm.device_exposure (
    person_id,
    device_concept_id,
    device_exposure_start_date,
    device_exposure_start_datetime,
    device_exposure_end_date,
    device_exposure_end_datetime,
    device_type_concept_id,
    unique_device_id,
    production_id,
    quantity,
    provider_id,
    visit_occurrence_id,
    visit_detail_id,
    device_source_value,
    device_source_concept_id,
    unit_concept_id,
    unit_source_value,
    unit_source_concept_id,
    RecordConnectionIdentifier,
    HospitalProviderSpellNumber,
    data_source
)
select
    distinct
        p.person_id,
        r.device_concept_id,
        r.device_exposure_start_date,
        r.device_exposure_start_datetime,
        r.device_exposure_end_date,
        r.device_exposure_end_datetime,
        r.device_type_concept_id,
        r.unique_device_id,
        r.production_id,
        r.quantity,
        r.provider_id,
        (
            select vo.visit_occurrence_id
            from cdm.visit_occurrence vo
            where vo.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber
            and vo.person_id = p.person_id
            and r.HospitalProviderSpellNumber is not null
            limit 1
        ) as visit_occurrence_id,
        (
            select vd.visit_detail_id
            from cdm.visit_detail vd
            where vd.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber
            and vd.person_id = p.person_id
            and r.HospitalProviderSpellNumber is not null
            limit 1
        ) as visit_detail_id,
        r.device_source_value,
        r.device_source_concept_id,
        r.unit_concept_id,
        r.unit_source_value,
        r.unit_source_concept_id,
        r.RecordConnectionIdentifier,
        r.HospitalProviderSpellNumber,
        r.data_source
from omop_staging.device_exposure_row r
    inner join cdm.person p
        on r.nhs_number = p.person_source_value
where 
    (
        r.HospitalProviderSpellNumber is not null and
        not exists (
            select 1
            from cdm.device_exposure vo
            where vo.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber
                and vo.person_id = p.person_id
                and vo.device_concept_id = r.device_concept_id
                and vo.device_exposure_start_date = r.device_exposure_start_date
                and vo.device_exposure_end_date = r.device_exposure_end_date        )
    )
    or
    (
        r.HospitalProviderSpellNumber is null and r.RecordConnectionIdentifier is null and
        not exists (
            select 1
            from cdm.device_exposure vo
            where vo.person_id = p.person_id
                and vo.device_concept_id = r.device_concept_id
                and vo.device_exposure_start_date = r.device_exposure_start_date
                and vo.device_exposure_end_date = r.device_exposure_end_date
                and (vo.device_concept_id != 0 or ((vo.device_source_value is null and r.device_source_value is null) or vo.device_source_value = r.device_source_value))
        )
    );

truncate table omop_staging.device_exposure_row;",
                cancellationToken);
    }
}