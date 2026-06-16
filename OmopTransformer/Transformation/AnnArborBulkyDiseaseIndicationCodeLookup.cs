using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ANN ARBOR BULKY DISEASE INDICATION CODE")]
internal class AnnArborBulkyDiseaseIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "X", new ValueWithNote("1633986", "Bulky disease present") },
            { "0", new ValueWithNote("0", "No bulky disease present") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
