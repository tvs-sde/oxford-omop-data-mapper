namespace OmopTransformer.RTDS.Parser;

internal class Rtds5DiagnosisCourseParser(string text)
{
    private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

    public IEnumerable<Rtds5DiagnosisCourse> Parse()
    {
        using var reader = new StringReader(_text);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            yield return new Rtds5DiagnosisCourse
            {
                PatientSer = csv.GetFieldOrNullWhenEmpty("PatientSer"),
                CourseSer = csv.GetFieldOrNullWhenEmpty("CourseSer"),
                DateStamp = csv.GetFieldOrNullWhenEmpty("DateStamp"),
                DiagnosisCode = csv.GetFieldOrNullWhenEmpty("DiagnosisCode"),
                DiagnosisTableName = csv.GetFieldOrNullWhenEmpty("DiagnosisTableName"),
                DiagnosisType = csv.GetFieldOrNullWhenEmpty("DiagnosisType"),
                End_date = csv.GetFieldOrNullWhenEmpty("End_date"),
                Start_date = csv.GetFieldOrNullWhenEmpty("Start_date")
            };
        }
    }
}