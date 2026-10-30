using System.Diagnostics;
using CsvHelper;
using Microsoft.Extensions.Logging;

namespace OmopTransformer.SACT.Staging;

internal class SactStaging : ISactStaging
{
    private readonly ILogger<SactStaging> _logger;
    private readonly StagingOptions _options;
    private readonly ISactInserter _sactInserter;

    public SactStaging(ILogger<SactStaging> logger, StagingOptions options, ISactInserter sactInserter)
    {
        _logger = logger;
        _options = options;
        _sactInserter = sactInserter;
    }

    public async Task StageData(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Staging sact data.");

        if (!File.Exists(_options.FileName))
        {
            _logger.LogError("File does not exist or is inaccessible. {0}", _options.FileName);
            Environment.ExitCode = (int)ExitCodes.FileDoesNotExist;
            return;
        }

        _logger.LogInformation("Reading {0}", _options.FileName);

        Stopwatch stopwatch = Stopwatch.StartNew();

        using var reader = new StreamReader(_options.FileName);
        using var csv = CsvReaderExtensions.CreateReader(reader);
        var records = new List<SactCsvRow>();
        while (await csv.ReadAsync())
        {
            var record = new SactCsvRow
            {
                NHS_Number = csv.GetString("NHS_Number"),
                Local_Patient_Identifier = csv.GetString("Local_Patient_Identifier"),
                NHS_Number_Status_Indicator_Code = csv.GetString("NHS_Number_Status_Indicator_Code"),
                Person_Family_Name = csv.GetString("Person_Family_Name"),
                Person_Given_Name = csv.GetString("Person_Given_Name"),
                Date_Of_Birth = csv.GetString("Date_Of_Birth"),
                Person_Stated_Gender_Code = csv.GetString("Person_Stated_Gender_Code"),
                Consultant_GMC_Code = csv.GetString("Consultant_GMC_Code"),
                Consultant_Specialty_Code = csv.GetString("Consultant_Specialty_Code"),
                Organisation_Identifier_Code_Of_Provider = csv.GetString("Organisation_Identifier_(Code_Of_Provider)"),
                Primary_Diagnosis = csv.GetString("Primary_Diagnosis"),
                Morphology_ICD_O = csv.GetString("Morphology_ICD-O"),
                Diagnosis_Code_SNOMED_CT = csv.GetString("Diagnosis_Code_(SNOMED_CT)"),
                Adjunctive_Therapy = csv.GetString("Adjunctive_Therapy"),
                Intent_Of_Treatment = csv.GetString("Intent_Of_Treatment"),
                Regimen = csv.GetString("Regimen"),
                Height_At_Start_Of_Regimen = csv.GetString("Height_At_Start_Of_Regimen"),
                Weight_At_Start_Of_Regimen = csv.GetString("Weight_At_Start_Of_Regimen"),
                Performance_Status_At_Start_Of_Regimen_Adult = csv.GetString("Performance_Status_At_Start_Of_Regimen_-_Adult"),
                Comorbidity_Adjustment = csv.GetString("Comorbidity_Adjustment"),
                Date_Decision_To_Treat = csv.GetString("Date_Decision_To_Treat"),
                Start_Date_Of_Regimen = csv.GetString("Start_Date_Of_Regimen"),
                Clinical_Trial = csv.GetString("Clinical_Trial"),
                Cycle_Number = csv.GetString("Cycle_Number"),
                Start_Date_Of_Cycle = csv.GetString("Start_Date_Of_Cycle"),
                Weight_At_Start_Of_Cycle = csv.GetString("Weight_At_Start_Of_Cycle"),
                Performance_Status_At_Start_Of_Cycle_Adult = csv.GetString("Performance_Status_At_Start_Of_Cycle_-_Adult"),
                Drug_Name = csv.GetString("Drug_Name"),
                DM_D = csv.GetString("DM+D"),
                Actual_Dose_Per_Administration = csv.GetString("Actual_Dose_Per_Administration"),
                Administration_Measurement_Per_Actual_Dose = csv.GetString("Administration_Measurement_Per_Actual_Dose"),
                Other_Administration_Measurement_Per_Actual_Dose = csv.GetString("Other_-_ Administration_Measurement_Per_Actual_Dose"),
                Unit_Of_Measurement_SNOMED_CT_DM_D = csv.GetString("Unit_Of_Measurement_(SNOMED_CT_DM+D)"),
                SACT_Administration_Route = csv.GetString("SACT_Administration_Route"),
                Route_Of_Administration_SNOMED_CT_DM_D = csv.GetString("Route_Of_Administration_(SNOMED_CT_DM+D)"),
                Administration_Date = csv.GetString("Administration_Date"),
                Organisation_Identifier_Of_SACT_Administration = csv.GetString("Organisation_Identifier_Of_SACT_Administration"),
                Regimen_Modification_Dose_Reduction = csv.GetString("Regimen_Modification_-_Dose_Reduction"),
                Regimen_Outcome_Summary_Curative_Completed_As_Planned = csv.GetString("Regimen_Outcome_Summary_-_Curative_(Completed_As_Planned)"),
                Regimen_Outcome_Summary_Curative_Not_Completed_As_Planned_Reason = csv.GetString("Regimen_Outcome_Summary_-_Curative_(Not_Completed_As_Planned)_Reason"),
                Other_Regimen_Outcome_Summary_Curative_Not_Completed_As_Planned_Reason = csv.GetString("Other_-_Regimen_Outcome_Summary_-_Curative_(Not_Completed_As_Planned)_Reason"),
                Regimen_Outcome_Summary_Non_Curative = csv.GetString("Regimen_Outcome_Summary_Non_Curative"),
                Regimen_Outcome_Summary_Toxicity = csv.GetString("Regimen_Outcome_Summary_Toxicity"),
                Patient_Postcode = GetPatientPostcode(csv)
            };

            records.Add(record);
        }

        stopwatch.Stop();

        _logger.LogInformation("{0} records read in {1}ms.", records.Count, stopwatch.ElapsedMilliseconds);

        await _sactInserter.Insert(records, cancellationToken);

        _logger.LogInformation("Staging complete.");
    }

    private static string? GetPatientPostcode(CsvReader csv)
    {
        if (csv.TryGetFieldIndex("Patient_Postcode", out var index) && index < csv.FieldCount)
        {
            return csv.GetString(index);
        }

        if (csv.TryGetFieldIndex("Patient_PostCode", out index) && index < csv.FieldCount)
        {
            return csv.GetString(index);
        }

        return null;
    }
}