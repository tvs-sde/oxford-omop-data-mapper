using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PLANNED CANCER TREATMENT TYPE")]
internal class PlannedCancerTreatmentTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Surgery") },
            { "02", new ValueWithNote(null, "External Beam Radiotherapy (excluding Proton Therapy)") },
            { "03", new ValueWithNote(null, "Chemotherapy") },
            { "04", new ValueWithNote(null, "Hormone Therapy") },
            { "05", new ValueWithNote(null, "Specialist Palliative Care") },
            { "06", new ValueWithNote(null, "Brachytherapy") },
            { "07", new ValueWithNote(null, "Biological Therapy") },
            { "08", new ValueWithNote(null, "Other (Retired 1 January 2013)") },
            { "09", new ValueWithNote(null, "Active Monitoring (Retired 1 January 2013)") },
            { "10", new ValueWithNote(null, "Other Active Treatment (not listed)") },
            { "12", new ValueWithNote(null, "Bisphosphonates") },
            { "13", new ValueWithNote(null, "Anti Cancer Drug - Other (not listed)") },
            { "14", new ValueWithNote(null, "Radiotherapy - Other (not listed)") },
            { "11", new ValueWithNote(null, "Not Applicable (No Active Treatment)") },
            { "99", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
