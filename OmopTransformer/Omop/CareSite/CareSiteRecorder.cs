using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.CareSite;

internal class CareSiteRecorder : ICareSiteRecorder
{
    private readonly Configuration _configuration;
    public CareSiteRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateCareSite<T>(IReadOnlyCollection<OmopCareSite<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.care_site_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "care_site_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        var dbRow = appender.CreateRow();

                        dbRow
                            .AppendValue(row.care_site_name)
                            .AppendValue(row.place_of_service_concept_id)
                            .AppendValue(row.location_id)
                            .AppendValue(row.care_site_source_value)
                            .AppendValue(row.place_of_service_source_value)
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


insert into cdm.care_site (
    care_site_name,
    place_of_service_concept_id,
    location_id,
    care_site_source_value,
    place_of_service_source_value,
    data_source
)
select
    distinct
        care_site_name,
        place_of_service_concept_id,
        location_id,
        care_site_source_value,
        place_of_service_source_value,
        data_source
from omop_staging.care_site_row up
where not exists (select 1 from cdm.care_site p where p.care_site_name = up.care_site_name);

truncate table omop_staging.care_site_row;
",
                cancellationToken);
    }
}