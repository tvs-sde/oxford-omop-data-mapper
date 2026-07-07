using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.Person;

internal class PersonRecorder : IPersonRecorder
{
    private readonly Configuration _configuration;

    public PersonRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdatePersons<T>(IReadOnlyCollection<OmopPerson<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.person_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "person_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        var dbRow = appender.CreateRow();

                        dbRow
                            .AppendValue(row.gender_concept_id)
                            .AppendValue(row.year_of_birth)
                            .AppendValue(row.month_of_birth)
                            .AppendValue(row.day_of_birth)
                            .AppendValue(row.birth_datetime)
                            .AppendValue(row.race_concept_id)
                            .AppendValue(row.ethnicity_concept_id)
                            .AppendValue(row.provider_id)
                            .AppendValue(row.care_site_id)
                            .AppendValue(row.person_source_value)
                            .AppendValue(row.gender_source_value)
                            .AppendValue(row.gender_source_concept_id)
                            .AppendValue(row.race_source_value)
                            .AppendValue(row.race_source_concept_id)
                            .AppendValue(row.ethnicity_source_value)
                            .AppendValue(row.ethnicity_source_concept_id)
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


insert into cdm.person
(
    gender_concept_id,
    year_of_birth,
    month_of_birth,
    day_of_birth,
    birth_datetime,
    race_concept_id,
    ethnicity_concept_id,
    location_id,
    provider_id,
    care_site_id,
    person_source_value,
    gender_source_value,
    gender_source_concept_id,
    race_source_value,
    race_source_concept_id,
    ethnicity_source_value,
    ethnicity_source_concept_id,
    data_source
)
select
    distinct
        gender_concept_id,
        year_of_birth,
        month_of_birth,
        day_of_birth,
        birth_datetime,
        race_concept_id,
        ethnicity_concept_id,
        null,
        provider_id,
        care_site_id,
        person_source_value,
        gender_source_value,
        gender_source_concept_id,
        race_source_value,
        race_source_concept_id,
        ethnicity_source_value,
        ethnicity_source_concept_id,
        data_source
from omop_staging.person_row as up
where not exists (select 1 from cdm.person as p where p.person_source_value = up.person_source_value);

update cdm.person
set
    gender_concept_id = coalesce(up.gender_concept_id, cdm.person.gender_concept_id),
    year_of_birth = coalesce(up.year_of_birth, cdm.person.year_of_birth),
    month_of_birth = coalesce(up.month_of_birth, cdm.person.month_of_birth),
    day_of_birth = coalesce(up.day_of_birth, cdm.person.day_of_birth),
    birth_datetime = coalesce(up.birth_datetime, cdm.person.birth_datetime),
    race_concept_id = coalesce(up.race_concept_id, cdm.person.race_concept_id),
    ethnicity_concept_id = coalesce(up.ethnicity_concept_id, cdm.person.ethnicity_concept_id),
    provider_id = coalesce(up.provider_id, cdm.person.provider_id),
    care_site_id = coalesce(up.care_site_id, cdm.person.care_site_id),
    person_source_value = coalesce(up.person_source_value, cdm.person.person_source_value),
    gender_source_value = coalesce(up.gender_source_value, cdm.person.gender_source_value),
    gender_source_concept_id = coalesce(up.gender_source_concept_id, cdm.person.gender_source_concept_id),
    race_source_value = coalesce(up.race_source_value, cdm.person.race_source_value),
    race_source_concept_id = coalesce(up.race_source_concept_id, cdm.person.race_source_concept_id),
    ethnicity_source_value = coalesce(up.ethnicity_source_value, cdm.person.ethnicity_source_value),
    ethnicity_source_concept_id = coalesce(up.ethnicity_source_concept_id, cdm.person.ethnicity_source_concept_id)
from omop_staging.person_row as up
where cdm.person.person_source_value = up.person_source_value
and (
    (up.gender_concept_id is not null and (cdm.person.gender_concept_id is null or cdm.person.gender_concept_id <> up.gender_concept_id)) or
    (up.year_of_birth is not null and (cdm.person.year_of_birth is null or cdm.person.year_of_birth <> up.year_of_birth)) or
    (up.month_of_birth is not null and (cdm.person.month_of_birth is null or cdm.person.month_of_birth <> up.month_of_birth)) or
    (up.day_of_birth is not null and (cdm.person.day_of_birth is null or cdm.person.day_of_birth <> up.day_of_birth)) or
    (up.birth_datetime is not null and (cdm.person.birth_datetime is null or cdm.person.birth_datetime <> up.birth_datetime)) or
    (up.race_concept_id is not null and (cdm.person.race_concept_id is null or cdm.person.race_concept_id <> up.race_concept_id)) or
    (up.ethnicity_concept_id is not null and (cdm.person.ethnicity_concept_id is null or cdm.person.ethnicity_concept_id <> up.ethnicity_concept_id)) or
    (up.provider_id is not null and (cdm.person.provider_id is null or cdm.person.provider_id <> up.provider_id)) or
    (up.care_site_id is not null and (cdm.person.care_site_id is null or cdm.person.care_site_id <> up.care_site_id)) or
    (up.person_source_value is not null and (cdm.person.person_source_value is null or cdm.person.person_source_value <> up.person_source_value)) or
    (up.gender_source_value is not null and (cdm.person.gender_source_value is null or cdm.person.gender_source_value <> up.gender_source_value)) or
    (up.gender_source_concept_id is not null and (cdm.person.gender_source_concept_id is null or cdm.person.gender_source_concept_id <> up.gender_source_concept_id)) or
    (up.race_source_value is not null and (cdm.person.race_source_value is null or cdm.person.race_source_value <> up.race_source_value)) or
    (up.race_source_concept_id is not null and (cdm.person.race_source_concept_id is null or cdm.person.race_source_concept_id <> up.race_source_concept_id)) or
    (up.ethnicity_source_value is not null and (cdm.person.ethnicity_source_value is null or cdm.person.ethnicity_source_value <> up.ethnicity_source_value)) or
    (up.ethnicity_source_concept_id is not null and (cdm.person.ethnicity_source_concept_id is null or cdm.person.ethnicity_source_concept_id <> up.ethnicity_source_concept_id))
);

truncate table omop_staging.person_row;

");
    }
}