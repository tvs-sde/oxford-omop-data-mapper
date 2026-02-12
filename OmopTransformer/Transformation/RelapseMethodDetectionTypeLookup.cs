using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("RELAPSE METHOD DETECTION TYPE")]
internal class RelapseMethodDetectionTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Morphology") },
            { "2", new ValueWithNote(null, "Flow") },
            { "3", new ValueWithNote(null, "Molecular") },
            { "4", new ValueWithNote(null, "Clinical Examination") },
            { "9", new ValueWithNote(null, "Other (not listed)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
