using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.VisitDetail;

internal class VisitDetailRecorder : IVisitDetailRecorder
{
    private readonly Configuration _configuration;

    public VisitDetailRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateVisitDetail<T>(IReadOnlyCollection<OmopVisitDetail<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.visit_detail_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "visit_detail_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        var dbRow = appender.CreateRow();

                        dbRow
                        .AppendValue(row.nhs_number)
                        .AppendValue(row.HospitalProviderSpellNumber)
                        .AppendValue(row.RecordConnectionIdentifier)
                        .AppendValue(row.visit_detail_concept_id)
                        .AppendValue(row.visit_detail_start_date)
                        .AppendValue(row.visit_detail_start_datetime)
                        .AppendValue(row.visit_detail_end_date)
                        .AppendValue(row.visit_detail_end_datetime)
                        .AppendValue(row.visit_detail_type_concept_id)
                        .AppendValue(row.provider_id)
                        .AppendValue(row.care_site_id)
                        .AppendValue(row.visit_detail_source_value)
                        .AppendValue(row.visit_detail_source_concept_id)
                        .AppendValue(row.admitted_from_concept_id)
                        .AppendValue(row.admitted_from_source_value)
                        .AppendValue(row.discharged_to_source_value)
                        .AppendValue(row.discharged_to_concept_id)
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


insert into cdm.visit_detail
(
	person_id,
	visit_detail_concept_id,
	visit_detail_start_date,
	visit_detail_start_datetime,
	visit_detail_end_date,
	visit_detail_end_datetime,
	visit_detail_type_concept_id,
	provider_id,
	care_site_id,
	visit_detail_source_value,
	visit_detail_source_concept_id,
	admitted_from_concept_id,
	admitted_from_source_value,
	discharged_to_source_value,
	discharged_to_concept_id,
	visit_occurrence_id,
	HospitalProviderSpellNumber,
	RecordConnectionIdentifier,
	data_source
)
select
    distinct
	    p.person_id,
	    r.visit_detail_concept_id,
	    r.visit_detail_start_date,
	    r.visit_detail_start_datetime,
	    r.visit_detail_end_date,
	    r.visit_detail_end_datetime,
	    r.visit_detail_type_concept_id,
	    r.provider_id,
	    r.care_site_id,
	    r.visit_detail_source_value,
	    r.visit_detail_source_concept_id,
	    r.admitted_from_concept_id,
	    r.admitted_from_source_value,
	    r.discharged_to_source_value,
	    r.discharged_to_concept_id,
	    (
		    case 
			    when r.HospitalProviderSpellNumber is not null then
			    (
				    select
					    vo.visit_occurrence_id
				    from cdm.visit_occurrence  vo
				    where vo.person_id = p.person_id 
					    and vo.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber
				    limit 1
			    )
		    else
			    case when r.RecordConnectionIdentifier is not null then
			    (
				    select
					    vo.visit_occurrence_id
				    from cdm.visit_occurrence  vo
				    where vo.person_id = p.person_id 
					    and vo.RecordConnectionIdentifier = r.RecordConnectionIdentifier
				    limit 1
			    )
			    else null
			    end
		    end
	    ) as visit_occurrence_id,

	    r.HospitalProviderSpellNumber,
	    r.RecordConnectionIdentifier,
        r.data_source
from omop_staging.visit_detail_row r
	inner join cdm.person p
		on r.nhs_number = p.person_source_value
where 
	(
		r.RecordConnectionIdentifier is not null 
		and not exists (
			select	*
			from cdm.visit_detail vo
			where vo.RecordConnectionIdentifier = r.RecordConnectionIdentifier
				and vo.person_id = p.person_id
			)
	)
	or
	(
		r.RecordConnectionIdentifier is null and r.HospitalProviderSpellNumber is null
		and not exists (
			select	*
			from cdm.visit_detail vo
			where vo.person_id = p.person_id
				and vo.visit_detail_start_date = r.visit_detail_start_date
				and vo.visit_detail_concept_id = r.visit_detail_concept_id
			)
	)
	or
	(
		r.HospitalProviderSpellNumber is not null 
		and not exists (
			select	*
			from cdm.visit_detail vo
			where vo.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber
				and vo.person_id = p.person_id
				and vo.visit_detail_start_date = r.visit_detail_start_date
				and vo.visit_detail_concept_id = r.visit_detail_concept_id
		)
		and exists ( -- Avoid inserting visit detail if the parent visit occurrence does not exist. Around 1/1,000,000 records exhibit this problem.
			select *
			from cdm.visit_occurrence vo
			where vo.HospitalProviderSpellNumber = r.HospitalProviderSpellNumber
				and vo.person_id = p.person_id
		)
	);

truncate table omop_staging.visit_detail_row;
",
                cancellationToken);

    }
}