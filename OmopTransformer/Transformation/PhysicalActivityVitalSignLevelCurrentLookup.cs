using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PHYSICAL ACTIVITY VITAL SIGN LEVEL (CURRENT)")]
internal class PhysicalActivityVitalSignLevelCurrentLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Achieves guidance level of physical activity") },
            { "2", new ValueWithNote(null, "Does not achieve guidance level of physical activity") },
            { "Z", new ValueWithNote(null, "Not Stated (patient asked but declined to provide a response)") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
