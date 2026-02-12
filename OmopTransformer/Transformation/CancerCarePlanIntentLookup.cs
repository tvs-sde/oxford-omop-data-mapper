using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CANCER CARE PLAN INTENT")]
internal class CancerCarePlanIntentLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "C", new ValueWithNote(null, "Curative") },
            { "P", new ValueWithNote(null, "Palliative anti-cancer (Retired 1 January 2013)") },
            { "S", new ValueWithNote(null, "Supportive (Retired 1 January 2013)") },
            { "N", new ValueWithNote(null, "No specific cancer treatment (Retired 1 January 2013)") },
            { "Z", new ValueWithNote(null, "Non-Curative") },
            { "X", new ValueWithNote(null, "No active treatment") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
