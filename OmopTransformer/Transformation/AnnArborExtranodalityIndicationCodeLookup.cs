using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ANN ARBOR EXTRANODALITY INDICATION CODE")]
internal class AnnArborExtranodalityIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "E", new ValueWithNote(null, "Extranodal involvement") },
            { "0", new ValueWithNote(null, "No extranodal involvement") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
