using Microsoft.Extensions.Logging.Abstractions;
using OmopTransformer;
using OmopTransformer.SACT.Staging;

namespace OmopTransformerTests;

[TestClass]
public class SactStagingTests
{
    [TestMethod]
    [DataRow("Patient_Postcode", " postcode ", " postcode ")]
    [DataRow("Patient_PostCode", " postcode ", " postcode ")]
    [DataRow("Patient_Postcode", "", "")]
    [DataRow(null, null, null)]
    public async Task StageData_PreservesAllRowsAndOptionalPostcode(
        string? postcodeHeader, string? postcodeValue, string? expectedPostcode)
    {
        string[] requiredHeaders =
        [
            "NHS_Number", "Local_Patient_Identifier", "NHS_Number_Status_Indicator_Code",
            "Person_Family_Name", "Person_Given_Name", "Date_Of_Birth", "Person_Stated_Gender_Code",
            "Consultant_GMC_Code", "Consultant_Specialty_Code", "Organisation_Identifier_(Code_Of_Provider)",
            "Primary_Diagnosis", "Morphology_ICD-O", "Diagnosis_Code_(SNOMED_CT)", "Adjunctive_Therapy",
            "Intent_Of_Treatment", "Regimen", "Height_At_Start_Of_Regimen", "Weight_At_Start_Of_Regimen",
            "Performance_Status_At_Start_Of_Regimen_-_Adult", "Comorbidity_Adjustment", "Date_Decision_To_Treat",
            "Start_Date_Of_Regimen", "Clinical_Trial", "Cycle_Number", "Start_Date_Of_Cycle",
            "Weight_At_Start_Of_Cycle", "Performance_Status_At_Start_Of_Cycle_-_Adult", "Drug_Name", "DM+D",
            "Actual_Dose_Per_Administration", "Administration_Measurement_Per_Actual_Dose",
            "Other_-_ Administration_Measurement_Per_Actual_Dose", "Unit_Of_Measurement_(SNOMED_CT_DM+D)",
            "SACT_Administration_Route", "Route_Of_Administration_(SNOMED_CT_DM+D)", "Administration_Date",
            "Organisation_Identifier_Of_SACT_Administration", "Regimen_Modification_-_Dose_Reduction",
            "Regimen_Outcome_Summary_-_Curative_(Completed_As_Planned)",
            "Regimen_Outcome_Summary_-_Curative_(Not_Completed_As_Planned)_Reason",
            "Other_-_Regimen_Outcome_Summary_-_Curative_(Not_Completed_As_Planned)_Reason",
            "Regimen_Outcome_Summary_Non_Curative", "Regimen_Outcome_Summary_Toxicity"
        ];
        var headers = requiredHeaders.ToList();
        var fields = Enumerable.Repeat("", headers.Count).ToList();
        fields[1] = "first";
        if (postcodeHeader != null)
        {
            headers.Add(postcodeHeader);
            fields.Add(postcodeValue!);
        }

        var path = Path.GetTempFileName();
        try
        {
            var first = string.Join(",", fields);
            fields[1] = "second";
            File.WriteAllText(path, string.Join(",", headers) + "\n" + first + "\n" + string.Join(",", fields));
            var inserter = new RecordingSactInserter();
            var staging = new SactStaging(
                NullLogger<SactStaging>.Instance, new StagingOptions { FileName = path }, inserter);

            await staging.StageData(CancellationToken.None);

            Assert.HasCount(2, inserter.Rows);
            Assert.AreEqual("first", inserter.Rows.First().Local_Patient_Identifier);
            Assert.AreEqual("second", inserter.Rows.Last().Local_Patient_Identifier);
            Assert.IsTrue(inserter.Rows.All(row => row.Patient_Postcode == expectedPostcode));
        }
        finally
        {
            File.Delete(path);
        }
    }

    private sealed class RecordingSactInserter : ISactInserter
    {
        public IReadOnlyCollection<SactCsvRow> Rows { get; private set; } = [];

        public Task Insert(IReadOnlyCollection<SactCsvRow> sactRows, CancellationToken cancellationToken)
        {
            Rows = sactRows;
            return Task.CompletedTask;
        }
    }
}
