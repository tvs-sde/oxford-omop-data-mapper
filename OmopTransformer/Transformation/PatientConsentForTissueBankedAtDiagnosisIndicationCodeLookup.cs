using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PATIENT CONSENT FOR TISSUE BANKED AT DIAGNOSIS INDICATION CODE")]
internal class PatientConsentForTissueBankedAtDiagnosisIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - tissue was banked at patient diagnosis (Retired 1 April 2020)") },
            { "N", new ValueWithNote(null, "No - tissue was not banked at patient diagnosis (Retired 1 April 2020)") },
            { "1", new ValueWithNote(null, "Patient approached, consented") },
            { "2", new ValueWithNote(null, "Patient approached, but declined") },
            { "3", new ValueWithNote(null, "Patient not approached") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded) (Retired 1 April 2024)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
