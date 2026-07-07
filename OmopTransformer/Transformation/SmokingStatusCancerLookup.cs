using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SMOKING STATUS (CANCER)")]
internal class SmokingStatusCancerLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("903657", "Current smoker") },
            { "2", new ValueWithNote("903651", "Ex-smoker") },
            { "4", new ValueWithNote("903653", "Never smoked") },
            { "9", new ValueWithNote("0", "Unknown (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}

