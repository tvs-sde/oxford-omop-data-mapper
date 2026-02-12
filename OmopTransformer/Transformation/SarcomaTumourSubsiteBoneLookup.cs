using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SARCOMA TUMOUR SUBSITE (BONE)")]
internal class SarcomaTumourSubsiteBoneLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "PR", new ValueWithNote(null, "Proximal") },
            { "DS", new ValueWithNote(null, "Distal") },
            { "DP", new ValueWithNote(null, "Diaphyseal (Middle)") },
            { "TO", new ValueWithNote(null, "Total") },
            { "OO", new ValueWithNote(null, "Other (not listed)") },
            { "NK", new ValueWithNote(null, "Not Known (Not recorded or test not carried out)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
