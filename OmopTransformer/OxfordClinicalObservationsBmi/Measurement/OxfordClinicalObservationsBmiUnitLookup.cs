using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordClinicalObservationsBmi.Measurement;

internal class OxfordClinicalObservationsBmiUnitLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } = new(StringComparer.OrdinalIgnoreCase)
    {
        { "kg", new ValueWithNote("9529", "Kilogram") },
        { "cm", new ValueWithNote("8582", "Centimeter") },
        { "kg/m2", new ValueWithNote("9531", "Kilogram per square meter") },
        { "<no data>", new ValueWithNote("0", "Unknown unit") },
        { "square metre", new ValueWithNote("0", "Not a supported measurement unit") },
        { "", new ValueWithNote("0", "Missing unit") }
    };

    public string[] ColumnNotes => [];
}
