using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("BIOPSY TYPE (CENTRAL NERVOUS SYSTEM TUMOURS)")]
internal class BiopsyTypeCentralNervousSystemTumoursLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Frame-based stereotactic biopsy") },
            { "2", new ValueWithNote(null, "Frameless stereotactic biopsy") },
            { "3", new ValueWithNote(null, "Open biopsy") },
            { "4", new ValueWithNote(null, "Percutaneous biopsy") },
            { "5", new ValueWithNote(null, "Endoscopic biopsy") },
            { "6", new ValueWithNote(null, "Other biopsy (not listed)") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
