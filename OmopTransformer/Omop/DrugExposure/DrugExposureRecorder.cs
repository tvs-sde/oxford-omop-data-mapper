using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.DrugExposure;

internal class DrugExposureRecorder : IDrugExposureRecorder
{
    private readonly Configuration _configuration;

    public DrugExposureRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateDrugExposure<T>(IReadOnlyCollection<OmopDrugExposure<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.drug_exposure_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "drug_exposure_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        foreach (var conceptId in row.drug_concept_id!)
                        {

                            var dbRow = appender.CreateRow();

                            dbRow
                                .AppendValue(row.nhs_number)
                                .AppendValue(conceptId)
                                .AppendValue(row.drug_exposure_start_date)
                                .AppendValue(row.drug_exposure_start_datetime)
                                .AppendValue(row.drug_exposure_end_date)
                                .AppendValue(row.drug_exposure_end_datetime)
                                .AppendValue(row.verbatim_end_date)
                                .AppendValue(row.drug_type_concept_id)
                                .AppendValue(row.stop_reason)
                                .AppendValue(row.refills)
                                .AppendValue(row.quantity)
                                .AppendValue(row.days_supply)
                                .AppendValue(row.sig)
                                .AppendValue(row.route_concept_id)
                                .AppendValue(row.lot_number)
                                .AppendValue(row.provider_id)
                                .AppendValue(row.drug_source_value)
                                .AppendValue(row.drug_source_concept_id)
                                .AppendValue(row.route_source_value)
                                .AppendValue(row.dose_unit_source_value)
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


insert into cdm.drug_exposure (
    person_id,
    drug_concept_id,
    drug_exposure_start_date,
    drug_exposure_start_datetime,
    drug_exposure_end_date,
    drug_exposure_end_datetime,
    verbatim_end_date,
    drug_type_concept_id,
    stop_reason,
    refills,
    quantity,
    days_supply,
    sig,
    route_concept_id,
    lot_number,
    provider_id,
    visit_occurrence_id,
    visit_detail_id,
    drug_source_value,
    drug_source_concept_id,
    route_source_value,
    dose_unit_source_value,
    RecordConnectionIdentifier,
    data_source
)
select
    distinct
        p.person_id,
        r.drug_concept_id,
        r.drug_exposure_start_date,
        r.drug_exposure_start_datetime,
        r.drug_exposure_end_date,
        r.drug_exposure_end_datetime,
        r.verbatim_end_date,
        r.drug_type_concept_id,
        r.stop_reason,
        r.refills,
        r.quantity,
        r.days_supply,
        r.sig,
        r.route_concept_id,
        r.lot_number,
        r.provider_id,
        (
            select vo.visit_occurrence_id
            from cdm.visit_occurrence vo
            where vo.RecordConnectionIdentifier = r.RecordConnectionIdentifier
                and p.person_id = vo.person_id
            limit 1
        ) as visit_occurrence_id,
        (
            select vd.visit_detail_id
            from cdm.visit_detail vd
            where vd.RecordConnectionIdentifier = r.RecordConnectionIdentifier
                and p.person_id = vd.person_id
            limit 1
        ) as visit_detail_id,
        r.drug_source_value,
        r.drug_source_concept_id,
        r.route_source_value,
        r.dose_unit_source_value,
        r.RecordConnectionIdentifier,
        r.data_source
from omop_staging.drug_exposure_row r
inner join cdm.person p on r.nhs_number = p.person_source_value
where 
    (
        r.RecordConnectionIdentifier is not null and
        not exists (
            select 1
            from cdm.drug_exposure vo
            where vo.RecordConnectionIdentifier = r.RecordConnectionIdentifier
                and vo.person_id = p.person_id
                and vo.drug_concept_id = r.drug_concept_id

        )
    )
    or
    (
        r.RecordConnectionIdentifier is null and
        not exists (
            select 1
            from cdm.drug_exposure vo
            where vo.person_id = p.person_id
                and vo.drug_concept_id = r.drug_concept_id
                and vo.drug_exposure_start_date = r.drug_exposure_start_date
                and (vo.drug_concept_id != 0 or ((vo.drug_source_value is null and r.drug_source_value is null) or vo.drug_source_value = r.drug_source_value))
        )
    );

truncate table omop_staging.drug_exposure_row;",
                cancellationToken);
    }
}