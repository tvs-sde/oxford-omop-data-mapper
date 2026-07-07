using System.Data;
using System.Diagnostics;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmopTransformer.SACT.Staging;

internal class SactInserter : ISactInserter
{
    private readonly Configuration _configuration;
    private readonly ILogger<SactInserter> _logger;

    public SactInserter(IOptions<Configuration> configuration, ILogger<SactInserter> logger)
    {
        _logger = logger;
        _configuration = configuration.Value;
    }

    public async Task Insert(IReadOnlyCollection<SactCsvRow> sactRows, CancellationToken cancellationToken)
    {
        if (sactRows == null) throw new ArgumentNullException(nameof(sactRows));

        _logger.LogInformation("Recording {0} sact rows.", sactRows.Count);

        var stopwatch = Stopwatch.StartNew();

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            using var appender = connection.CreateAppender("omop_staging", "sact_staging");
            {
                foreach (var row in sactRows)
                {
                    var dbRow = appender.CreateRow();

                    dbRow
                        .AppendValue(row.NHS_Number)
                        .AppendValue(row.Local_Patient_Identifier)
                        .AppendValue(row.NHS_Number_Status_Indicator_Code)
                        .AppendValue(row.Person_Family_Name)
                        .AppendValue(row.Person_Given_Name)
                        .AppendValue(row.Date_Of_Birth)
                        .AppendValue(row.Person_Stated_Gender_Code)
                        .AppendValue(row.Patient_Postcode)
                        .AppendValue(row.Consultant_GMC_Code)
                        .AppendValue(row.Consultant_Specialty_Code)
                        .AppendValue(row.Organisation_Identifier_Code_Of_Provider)
                        .AppendValue(row.Primary_Diagnosis)
                        .AppendValue(row.Morphology_ICD_O)
                        .AppendValue(row.Diagnosis_Code_SNOMED_CT)
                        .AppendValue(row.Adjunctive_Therapy)
                        .AppendValue(row.Intent_Of_Treatment)
                        .AppendValue(row.Regimen)
                        .AppendValue(row.Height_At_Start_Of_Regimen)
                        .AppendValue(row.Weight_At_Start_Of_Regimen)
                        .AppendValue(row.Performance_Status_At_Start_Of_Regimen_Adult)
                        .AppendValue(row.Comorbidity_Adjustment)
                        .AppendValue(row.Date_Decision_To_Treat)
                        .AppendValue(row.Start_Date_Of_Regimen)
                        .AppendValue(row.Clinical_Trial)
                        .AppendValue(row.Cycle_Number)
                        .AppendValue(row.Start_Date_Of_Cycle)
                        .AppendValue(row.Weight_At_Start_Of_Cycle)
                        .AppendValue(row.Performance_Status_At_Start_Of_Cycle_Adult)
                        .AppendValue(row.Drug_Name)
                        .AppendValue(row.DM_D)
                        .AppendValue(row.Actual_Dose_Per_Administration)
                        .AppendValue(row.Administration_Measurement_Per_Actual_Dose)
                        .AppendValue(row.Other_Administration_Measurement_Per_Actual_Dose)
                        .AppendValue(row.Unit_Of_Measurement_SNOMED_CT_DM_D)
                        .AppendValue(row.SACT_Administration_Route)
                        .AppendValue(row.Route_Of_Administration_SNOMED_CT_DM_D)
                        .AppendValue(row.Administration_Date)
                        .AppendValue(row.Organisation_Identifier_Of_SACT_Administration)
                        .AppendValue(row.Regimen_Modification_Dose_Reduction)
                        .AppendValue(row.Regimen_Outcome_Summary_Curative_Completed_As_Planned)
                        .AppendValue(row.Regimen_Outcome_Summary_Curative_Not_Completed_As_Planned_Reason)
                        .AppendValue(row.Other_Regimen_Outcome_Summary_Curative_Not_Completed_As_Planned_Reason)
                        .AppendValue(row.Regimen_Outcome_Summary_Non_Curative)
                        .AppendValue(row.Regimen_Outcome_Summary_Toxicity)
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

        stopwatch.Stop();

        _logger.LogTrace("Inserting rows took {0}ms.", stopwatch.ElapsedMilliseconds);
    }
}