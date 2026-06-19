using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.Provider;

internal class ProviderRecorder : IProviderRecorder
{
    private readonly Configuration _configuration;

    public ProviderRecorder(IOptions<Configuration> configuration)
    {
        _configuration = configuration.Value;
    }

    public async Task InsertUpdateProvider<T>(IReadOnlyCollection<OmopProvider<T>> records, string dataSource, CancellationToken cancellationToken)
    {
        if (records == null) throw new ArgumentNullException(nameof(records));

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync("truncate table omop_staging.provider_row;");

        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            try
            {
                using var appender = connection.CreateAppender("omop_staging", "provider_row");
                {
                    foreach (var row in records)
                    {
                        if (row.IsValid == false)
                            continue;

                        var dbRow = appender.CreateRow();

                        dbRow
                            .AppendValue(row.provider_name)
                            .AppendValue(row.npi)
                            .AppendValue(row.dea)
                            .AppendValue(row.specialty_concept_id)
                            .AppendValue(row.care_site_id)
                            .AppendValue(row.year_of_birth)
                            .AppendValue(row.gender_concept_id)
                            .AppendValue(row.provider_source_value)
                            .AppendValue(row.specialty_source_value)
                            .AppendValue(row.specialty_source_concept_id)
                            .AppendValue(row.gender_source_value)
                            .AppendValue(row.gender_source_concept_id)
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


insert into cdm.provider (
    provider_name,
    npi,
    dea,
    specialty_concept_id,
    care_site_id,
    year_of_birth,
    gender_concept_id,
    provider_source_value,
    specialty_source_value,
    specialty_source_concept_id,
    gender_source_value,
    gender_source_concept_id,
    data_source
)
select
    distinct
        provider_name,
        npi,
        dea,
        specialty_concept_id,
        care_site_id,
        year_of_birth,
        gender_concept_id,
        provider_source_value,
        specialty_source_value,
        specialty_source_concept_id,
        gender_source_value,
        gender_source_concept_id,
        data_source
from omop_staging.provider_row r
where 
    not exists (
        select 1
        from cdm.provider p
        where p.provider_name = r.provider_name
            and p.specialty_concept_id = r.specialty_concept_id
            and p.specialty_source_value = r.specialty_source_value
    );

truncate table omop_staging.provider_row;",
                cancellationToken);
    }
}