using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.Location;

internal class LocationRecorder : ILocationRecorder
{
    private readonly Configuration _configuration;

    public LocationRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateLocations<T>(IReadOnlyCollection<OmopLocation<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.location_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "location_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        var dbRow = appender.CreateRow();

                        dbRow
                            .AppendValue(row.address_1)
                            .AppendValue(row.address_2)
                            .AppendValue(row.city)
                            .AppendValue(row.state)
                            .AppendValue(row.zip)
                            .AppendValue(row.county)
                            .AppendValue(row.location_source_value)
                            .AppendValue(row.country_concept_id)
                            .AppendValue(row.country_source_value)
                            .AppendValue((float?)row.latitude)
                            .AppendValue((float?)row.longitude)
                            .AppendValue(row.nhs_number)
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


with locationwithrow as (
    select
        address_1,
        address_2,
        city,
        state,
        zip,
        county,
        location_source_value,
        country_concept_id,
        country_source_value,
        latitude,
        longitude,
        row_number() over (
            partition by
                address_1,
                address_2,
                city,
                state,
                zip,
                county,
                country_concept_id,
                country_source_value,
                latitude,
                longitude
            order by null
        ) as rownumber,
        data_source
    from omop_staging.location_row l
)
insert into cdm.location (
    address_1,
    address_2,
    city,
    state,
    zip,
    county,
    location_source_value,
    country_concept_id,
    country_source_value,
    latitude,
    longitude,
    data_source
)
select
    l.address_1,
    l.address_2,
    l.city,
    l.state,
    l.zip,
    l.county,
    l.location_source_value,
    l.country_concept_id,
    l.country_source_value,
    l.latitude,
    l.longitude,
    l.data_source
from locationwithrow l
where not exists (
    select 1
    from cdm.location
    where address_1 is not distinct from l.address_1
        and address_2 is not distinct from l.address_2
        and city is not distinct from l.city
        and state is not distinct from l.state
        and zip is not distinct from l.zip
        and county is not distinct from l.county
        and country_concept_id is not distinct from l.country_concept_id
        and country_source_value is not distinct from l.country_source_value
        and latitude is not distinct from l.latitude
        and longitude is not distinct from l.longitude
)
and l.rownumber = 1;

update cdm.person
set location_id = cdm.location_id
from omop_staging.location_row l
inner join cdm.location cdm on l.address_1 is not distinct from cdm.address_1
    and l.address_2 is not distinct from cdm.address_2
    and l.city is not distinct from cdm.city
    and l.state is not distinct from cdm.state
    and l.zip is not distinct from cdm.zip
    and l.county is not distinct from cdm.county
    and l.country_concept_id is not distinct from cdm.country_concept_id
    and l.country_source_value is not distinct from cdm.country_source_value
    and l.latitude is not distinct from cdm.latitude
    and l.longitude is not distinct from cdm.longitude
where cdm.person.person_source_value = l.nhsnumber;

truncate table omop_staging.location_row;",
                cancellationToken);
    }
}