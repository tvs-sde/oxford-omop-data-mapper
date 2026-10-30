using OmopTransformer.OxfordGP.Staging;
using OmopTransformer.RTDS.Parser;
using OmopTransformer.SUS.Staging.Inpatient.CCMDS;

namespace OmopTransformerTests;

[TestClass]
public class CsvParserTests
{
    [TestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public void RtdsPlan_HandlesOptionalColumnAndPreservesUntrimmedValues(bool includeOptionalColumn)
    {
        var header = "ProcedureCode,AttributeValue,PatientSer,DueDateTime,NonScheduledActivityCode,CourseSer,NonScheduledActivitySer,ActivityName,Description,Start_date,End_date";
        var row = " code ,   ,patient,,,,,,\"quoted, description\",,";
        if (includeOptionalColumn)
        {
            header += ",ProcedureCodeSer";
            row += ",optional";
        }

        var records = new Rtds2BPlanParser(header + "\n" + row + "\n" + row).Parse().ToList();

        Assert.HasCount(2, records);
        Assert.AreEqual(" code ", records[0].ProcedureCode);
        Assert.IsNull(records[0].AttributeValue);
        Assert.AreEqual("patient", records[0].PatientSer);
        Assert.AreEqual("quoted, description", records[0].Description);
        Assert.AreEqual(includeOptionalColumn ? "optional" : null, records[0].ProcedureCodeSer);
    }

    [TestMethod]
    public void RtdsAttendances_SkipsRowsWithWrongFieldCounts()
    {
        const string header = "ScheduledActivitySer,ScheduledStartTime,AttributeValue,CourseSer,ProcedureCode,PatientSer,ScheduledActivityCode,Description,ActualStartDateTime_s,ActualEndDateTime_s,Start_date,End_date";
        const string valid = "activity,,,,,patient,,,,,,";
        var records = new Rtds2AAttendancesParser(
            header + "\n" + valid + "\nshort,row\n" + valid + ",extra\n" + valid).Parse().ToList();

        Assert.HasCount(2, records);
        Assert.AreEqual("activity", records[0].ScheduledActivitySer);
        Assert.AreEqual("patient", records[1].PatientSer);
    }

    [TestMethod]
    public void OxfordGpDemographics_TrimsFieldsAndRetainsAllRows()
    {
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllText(path,
                "Patient Identifier,NHS Number,Forename,Surname,DOB,Postcode,DateofDeath\n" +
                " first , ,\" Given, Name \",Family,2000-01-01, OX1 1AA ,\n" +
                "second,,,,,,\n");

            var records = new OxfordGPParser().ReadDemographicFile(path, CancellationToken.None).ToList();

            Assert.HasCount(2, records);
            Assert.AreEqual("first", records[0].PatientIdentifier);
            Assert.IsNull(records[0].NHSNumber);
            Assert.AreEqual("Given, Name", records[0].Forename);
            Assert.AreEqual("OX1 1AA", records[0].Postcode);
            Assert.AreEqual("second", records[1].PatientIdentifier);
        }
        finally
        {
            File.Delete(path);
        }
    }

    [TestMethod]
    public void SusCcmds_ReadsRepeatedFieldsByPosition()
    {
        string[] namedHeaders =
        [
            "Generated Record ID", "Load Staging Date", "Critical Care Period Sequence Number",
            "CDS Version on the episodes", "HES EPITYPE of the episode", "CDS Interchange ID",
            "HES EPISTAT of the episode", "Event Date", "Activity Date (Critical Care)",
            "Critical Care Period Type", "Critical Care Episode Relationship", "Critical Care Unit Function",
            "Critical Care Start Date", "Critical Care Start Time", "Critical Care Period Discharge Date",
            "Critical Care Period Discharge Time", "Critical Care Period Local Identifier", "Gestation Length At Delivery",
            "Critical Care Sequence Number (Derived)", "Total number of Critical Care Activities (Derived)",
            "Last Record for this Critical Care Period Indicator (Derived)",
            "Critical Care Activity to Episode Relationship (Derived)", "Person Weight"
        ];
        var headers = namedHeaders.Concat(Enumerable.Range(0, 40).Select(i => "Repeated" + i));
        var fields = Enumerable.Repeat("", 63).ToArray();
        fields[0] = " record ";
        fields[23] = " activity ";
        fields[43] = " drug ";
        var path = Path.GetTempFileName();
        try
        {
            File.WriteAllText(path, string.Join(",", headers) + "\n" + string.Join(",", fields));

            var record = new SusCCMDSParser().ReadFile(path, CancellationToken.None).Single();

            Assert.AreEqual("record", record.Row.GeneratedRecordID);
            Assert.AreEqual("activity", record.ActivityCodes.Single().CriticalCareActivityCode);
            Assert.AreEqual("drug", record.HighCostDrugs.Single().CriticalCareHighCostDrugs);
        }
        finally
        {
            File.Delete(path);
        }
    }
}
