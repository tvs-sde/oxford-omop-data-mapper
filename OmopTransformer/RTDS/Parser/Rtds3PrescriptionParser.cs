namespace OmopTransformer.RTDS.Parser;

internal class Rtds3PrescriptionParser(string text)
{
    private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

    public IEnumerable<Rtds3Prescription> Parse()
    {
        using var reader = new StringReader(_text);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            yield return new Rtds3Prescription
            {
                PatientSer = csv.GetFieldOrNullWhenEmpty("PatientSer"),
                CourseSer = csv.GetFieldOrNullWhenEmpty("CourseSer"),
                TreatmentType = csv.GetFieldOrNullWhenEmpty("TreatmentType"),
                NoFields = csv.GetFieldOrNullWhenEmpty("NoFields"),
                PreDescribedDose = csv.GetFieldOrNullWhenEmpty("PreDescribedDose"),
                PlanSetupSer = csv.GetFieldOrNullWhenEmpty("PlanSetupSer"),
                StartDateTime = csv.GetFieldOrNullWhenEmpty("StartDateTime"),
                TotDeliveredActualDose = csv.GetFieldOrNullWhenEmpty("TotDeliveredActualDose"),
                NoFracs = csv.GetFieldOrNullWhenEmpty("NoFracs"),
                PlanNameUpper = csv.GetFieldOrNullWhenEmpty("PlanNameUpper"),
                Start_date = csv.GetFieldOrNullWhenEmpty("Start_date"),
                End_date = csv.GetFieldOrNullWhenEmpty("End_date"),
                Expression1 = csv.GetFieldOrNullWhenEmpty("Expression1")
            };
        }
    }
}