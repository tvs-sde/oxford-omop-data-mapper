using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PATIENT DIAGNOSIS INDICATOR (DIABETES)")]
internal class PatientDiagnosisIndicatorDiabetesLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - patient diagnosis made") },
            { "N", new ValueWithNote(null, "No - patient diagnosis not made") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
