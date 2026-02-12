using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ANN ARBOR SPLENIC INDICATION CODE")]
internal class AnnArborSplenicIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "S", new ValueWithNote(null, "Spleen involvement or splenomegaly") },
            { "0", new ValueWithNote(null, "No spleen involvement or splenomegaly") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
