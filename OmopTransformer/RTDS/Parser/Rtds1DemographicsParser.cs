namespace OmopTransformer.RTDS.Parser;

internal class Rtds1DemographicsParser(string text)
{
    private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

    public IEnumerable<Rtds1Demographics> Parse()
    {
        using var reader = new StringReader(_text);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            yield return new Rtds1Demographics
            {
                PatientSer = csv.GetFieldOrNullWhenEmpty("PatientSer"),
                PatientId = csv.GetFieldOrNullWhenEmpty("PatientId"),
                PatientId2 = csv.GetFieldOrNullWhenEmpty("PatientId2"),
                UniversalPatientId = csv.GetFieldOrNullWhenEmpty("UniversalPatientId"),
                SSN = csv.GetFieldOrNullWhenEmpty("SSN"),
                FirstName = csv.GetFieldOrNullWhenEmpty("FirstName"),
                LastName = csv.GetFieldOrNullWhenEmpty("LastName"),
                DateOfBirth = csv.GetFieldOrNullWhenEmpty("DateOfBirth"),
                Sex = csv.GetFieldOrNullWhenEmpty("Sex"),
                DoctorId = csv.GetFieldOrNullWhenEmpty("DoctorId"),
                CourseSer = csv.GetFieldOrNullWhenEmpty("CourseSer"),
                Expression1 = csv.GetFieldOrNullWhenEmpty("Expression1"),
                StartDateTime = csv.GetFieldOrNullWhenEmpty("StartDateTime"),
                CompletedDateTime = csv.GetFieldOrNullWhenEmpty("CompletedDateTime"),
                End_date = csv.GetFieldOrNullWhenEmpty("End_date"),
                Start_date = csv.GetFieldOrNullWhenEmpty("Start_date")
            };
        }
    }
}