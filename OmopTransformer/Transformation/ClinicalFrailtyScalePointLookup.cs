using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CLINICAL FRAILTY SCALE POINT")]
internal class ClinicalFrailtyScalePointLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Very Fit") },
            { "2", new ValueWithNote(null, "Well") },
            { "3", new ValueWithNote(null, "Managing Well") },
            { "4", new ValueWithNote(null, "Vulnerable") },
            { "5", new ValueWithNote(null, "Mildly Frail") },
            { "6", new ValueWithNote(null, "Moderately Frail") },
            { "7", new ValueWithNote(null, "Severely Frail") },
            { "8", new ValueWithNote(null, "Very Severely Frail") },
            { "9", new ValueWithNote(null, "Terminally Ill") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
