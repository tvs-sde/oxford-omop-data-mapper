using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PERFORMANCE STATUS (ADULT)")]
internal class PerformanceStatusAdultLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "0", new ValueWithNote(null, "Able to carry out all normal activity without restriction") },
            { "1", new ValueWithNote(null, "Restricted in strenuous activity but ambulatory and able to carry out light work") },
            { "2", new ValueWithNote(null, "Ambulatory and capable of all self-care but unable to carry out any work activities; up and about more than 50% of waking hours") },
            { "3", new ValueWithNote(null, "Symptomatic and in a chair or in bed for greater than 50% of the day but not bedridden") },
            { "4", new ValueWithNote(null, "Completely disabled; cannot carry out any self-care; totally confined to bed or chair") },
            { "9", new ValueWithNote(null, "Not Recorded") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
