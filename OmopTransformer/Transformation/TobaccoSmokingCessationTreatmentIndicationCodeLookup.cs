using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE")]
internal class TobaccoSmokingCessationTreatmentIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Patient treated") },
            { "2", new ValueWithNote(null, "Patient not treated") },
            { "3", new ValueWithNote(null, "Patient offered treatment but declined") },
            { "8", new ValueWithNote(null, "Not Applicable (Not current tobacco user)") },
            { "9", new ValueWithNote(null, "Not Known (Not recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
