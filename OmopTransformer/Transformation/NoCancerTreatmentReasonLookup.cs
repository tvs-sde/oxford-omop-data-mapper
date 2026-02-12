using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("NO CANCER TREATMENT REASON")]
internal class NoCancerTreatmentReasonLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Patient declined treatment") },
            { "02", new ValueWithNote(null, "Unfit: poor performance status") },
            { "03", new ValueWithNote(null, "Unfit: significant co-morbidity") },
            { "04", new ValueWithNote(null, "Unfit: advanced stage cancer") },
            { "05", new ValueWithNote(null, "Unknown primary site") },
            { "06", new ValueWithNote(null, "Died before treatment") },
            { "07", new ValueWithNote(null, "No anti-cancer treatment available") },
            { "08", new ValueWithNote(null, "Other (not listed)") },
            { "09", new ValueWithNote(null, "Watchful Waiting (Retired 1 January 2013)") },
            { "10", new ValueWithNote(null, "Monitoring Only") },
            { "99", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
