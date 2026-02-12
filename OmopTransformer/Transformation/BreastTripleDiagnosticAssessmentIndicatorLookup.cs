using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("BREAST TRIPLE DIAGNOSTIC ASSESSMENT INDICATOR")]
internal class BreastTripleDiagnosticAssessmentIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - Breast Triple Diagnostic Assessment was completed") },
            { "N", new ValueWithNote(null, "No - Breast Triple Diagnostic Assessment was not completed") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
