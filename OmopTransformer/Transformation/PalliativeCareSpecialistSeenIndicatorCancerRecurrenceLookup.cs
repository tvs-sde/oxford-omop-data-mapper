using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PALLIATIVE CARE SPECIALIST SEEN INDICATOR (CANCER RECURRENCE)")]
internal class PalliativeCareSpecialistSeenIndicatorCancerRecurrenceLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - the patient was seen by a palliative care specialist") },
            { "N", new ValueWithNote(null, "No - the patient was not seen by a palliative care specialist") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
