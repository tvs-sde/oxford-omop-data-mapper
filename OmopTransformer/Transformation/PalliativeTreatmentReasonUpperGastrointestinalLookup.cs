using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PALLIATIVE TREATMENT REASON (UPPER GASTROINTESTINAL)")]
internal class PalliativeTreatmentReasonUpperGastrointestinalLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Extensive intrahepatic disease") },
            { "2", new ValueWithNote(null, "Widespread disease") },
            { "3", new ValueWithNote(null, "Both (extensive intrahepatic disease and widespread disease)") },
            { "4", new ValueWithNote(null, "Biliary obstruction") },
            { "5", new ValueWithNote(null, "Gastric outlet obstruction") },
            { "6", new ValueWithNote(null, "Pain") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
