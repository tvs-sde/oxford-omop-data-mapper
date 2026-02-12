using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("STEM CELL INFUSION SOURCE CODE")]
internal class StemCellInfusionSourceCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "B", new ValueWithNote(null, "Bone Marrow") },
            { "P", new ValueWithNote(null, "Peripheral Blood") },
            { "C", new ValueWithNote(null, "Cord") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}