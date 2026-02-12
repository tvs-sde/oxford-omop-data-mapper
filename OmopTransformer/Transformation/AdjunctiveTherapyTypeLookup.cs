using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ADJUNCTIVE THERAPY TYPE")]
internal class AdjunctiveTherapyTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Adjuvant Therapy") },
            { "2", new ValueWithNote(null, "Neoadjuvant Therapy") },
            { "3", new ValueWithNote(null, "Not Applicable (Primary Treatment)") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
