using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("GENERAL MEDICAL PRACTICE CODE (PATIENT REGISTRATION)")]
internal class GeneralMedicalPracticeCodePatientRegistrationLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "V81997", new ValueWithNote(null, "No registered GP practice") },
            { "V81998", new ValueWithNote(null, "GP practice code not applicable") },
            { "V81999", new ValueWithNote(null, "GP practice code not known") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
