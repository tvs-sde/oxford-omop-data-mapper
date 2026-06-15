using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("BIOPSY ANAESTHETIC TYPE")]
internal class BiopsyAnaestheticTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("4303995", "Local anaesthetic") },
            { "2", new ValueWithNote("4219502", "Sedation") },
            { "3", new ValueWithNote("4174669", "General anaesthetic") },
            { "9", new ValueWithNote("0", "Not Known (Not Recorded)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
