using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SENTINEL LYMPH NODE BIOPSY OUTCOME")]
internal class SentinelLymphNodeBiopsyOutcomeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "P", new ValueWithNote(null, "Malignant (cancer is present in the sentinel lymph node).") },
            { "N", new ValueWithNote(null, "No Malignancy (cancer is not present in the sentinel lymph node).") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
