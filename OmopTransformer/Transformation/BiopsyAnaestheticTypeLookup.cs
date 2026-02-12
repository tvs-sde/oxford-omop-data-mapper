using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("BIOPSY ANAESTHETIC TYPE")]
internal class BiopsyAnaestheticTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Local anaesthetic") },
            { "2", new ValueWithNote(null, "Sedation") },
            { "3", new ValueWithNote(null, "General anaesthetic") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
