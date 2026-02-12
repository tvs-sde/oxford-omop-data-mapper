using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SMOKING STATUS (CANCER)")]
internal class SmokingStatusCancerLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Current smoker") },
            { "2", new ValueWithNote(null, "Ex-smoker") },
            { "4", new ValueWithNote(null, "Never smoked") },
            { "9", new ValueWithNote(null, "Unknown (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
