namespace OmopTransformer.RTDS.Parser;

internal class Rtds4ExposuresParser(string text)
{
    private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

    public IEnumerable<Rtds4Exposures> Parse()
    {
        using var reader = new StringReader(_text);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            yield return new Rtds4Exposures
            {
                PatientSer = csv.GetFieldOrNullWhenEmpty("PatientSer"),
                CourseSer = csv.GetFieldOrNullWhenEmpty("CourseSer"),
                RadiationSer = csv.GetFieldOrNullWhenEmpty("RadiationSer"),
                NominalEnergy = csv.GetFieldOrNullWhenEmpty("NominalEnergy"),
                RadiationType = csv.GetFieldOrNullWhenEmpty("RadiationType"),
                PlanSetupSer = csv.GetFieldOrNullWhenEmpty("PlanSetupSer"),
                EventNumber = csv.GetFieldOrNullWhenEmpty("EventNumber"),
                MachineId = csv.GetFieldOrNullWhenEmpty("MachineId"),
                PlanName = csv.GetFieldOrNullWhenEmpty("PlanName"),
                Start_date = csv.GetFieldOrNullWhenEmpty("Start_date"),
                End_date = csv.GetFieldOrNullWhenEmpty("End_date"),
                TreatmentDateTime = csv.GetFieldOrNullWhenEmpty("TreatmentDateTime"),
                storedprocedure_version = csv.GetFieldOrNullWhenEmpty("storedprocedure_version")
            };
        }
    }
}