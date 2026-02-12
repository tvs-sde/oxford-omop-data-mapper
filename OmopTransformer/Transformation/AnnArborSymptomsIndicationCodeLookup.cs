using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ANN ARBOR SYMPTOMS INDICATION CODE")]
internal class AnnArborSymptomsIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "A", new ValueWithNote(null, "No symptoms") },
            { "B", new ValueWithNote(null, "Presence of any of: unexplained persistent or recurrent fever (greater than 38 C / 101.5 F), drenching night sweats, unexplained weight loss of 10% or more within the last 6 months") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
