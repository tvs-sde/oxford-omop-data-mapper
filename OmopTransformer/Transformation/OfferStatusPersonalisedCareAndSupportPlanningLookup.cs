using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("OFFER STATUS (PERSONALISED CARE AND SUPPORT PLANNING)")]
internal class OfferStatusPersonalisedCareAndSupportPlanningLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Offered and Undecided") },
            { "02", new ValueWithNote(null, "Offered and Declined") },
            { "03", new ValueWithNote(null, "Offered and Accepted") },
            { "04", new ValueWithNote(null, "Not Offered") },
            { "05", new ValueWithNote(null, "Offered but patient unable to complete") },
            { "06", new ValueWithNote(null, "Not Offered: Other reason") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
