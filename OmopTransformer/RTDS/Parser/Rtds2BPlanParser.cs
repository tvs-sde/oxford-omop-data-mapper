namespace OmopTransformer.RTDS.Parser;

internal class Rtds2BPlanParser(string text)
{
    private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

    public IEnumerable<Rtds2BPlan> Parse()
    {
        using var reader = new StringReader(_text);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            yield return new Rtds2BPlan
            {
                ProcedureCode = csv.GetFieldOrNullWhenEmpty("ProcedureCode"),
                AttributeValue = csv.GetFieldOrNullWhenEmpty("AttributeValue"),
                PatientSer = csv.GetFieldOrNullWhenEmpty("PatientSer"),
                DueDateTime = csv.GetFieldOrNullWhenEmpty("DueDateTime"),
                NonScheduledActivityCode = csv.GetFieldOrNullWhenEmpty("NonScheduledActivityCode"),
                CourseSer = csv.GetFieldOrNullWhenEmpty("CourseSer"),
                NonScheduledActivitySer = csv.GetFieldOrNullWhenEmpty("NonScheduledActivitySer"),
                ActivityName = csv.GetFieldOrNullWhenEmpty("ActivityName"),
                Description = csv.GetFieldOrNullWhenEmpty("Description"),
                Start_date = csv.GetFieldOrNullWhenEmpty("Start_date"),
                End_date = csv.GetFieldOrNullWhenEmpty("End_date"),
                ProcedureCodeSer = csv.GetFieldOrNullWhenEmptyIfExists("ProcedureCodeSer")
            };
        }
    }
}