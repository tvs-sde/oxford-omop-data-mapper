using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SEVERE CARDIORESPIRATORY DISEASE INDICATOR")]
internal class SevereCardiorespiratoryDiseaseIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - the patient has severe cardiorespiratory disease.") },
            { "N", new ValueWithNote(null, "No - the patient does not have severe cardiorespiratory disease.") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
