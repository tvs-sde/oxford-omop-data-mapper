using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("STEM CELL INFUSION DONOR TYPE")]
internal class StemCellInfusionDonorTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Autologous") },
            { "2", new ValueWithNote(null, "Allogenic - Sibling") },
            { "3", new ValueWithNote(null, "Allogenic - Haplo") },
            { "4", new ValueWithNote(null, "Allogenic - Unrelated") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}