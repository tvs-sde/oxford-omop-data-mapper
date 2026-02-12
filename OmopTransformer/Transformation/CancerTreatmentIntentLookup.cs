using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CANCER TREATMENT INTENT")]
internal class CancerTreatmentIntentLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Curative") },
            { "02", new ValueWithNote(null, "Palliative") },
            { "03", new ValueWithNote(null, "Disease Modification (Drug / treatment specific)") },
            { "04", new ValueWithNote(null, "Diagnostic (Surgery specific)") },
            { "05", new ValueWithNote(null, "Staging (Surgery specific)") },
            { "06", new ValueWithNote(null, "Uncertain of treatment intent") },
            { "08", new ValueWithNote(null, "Other (not listed) (Retired 1 April 2020)") },
            { "98", new ValueWithNote(null, "Other (not listed)") },
            { "A", new ValueWithNote(null, "Adjuvant (Retired 1 January 2013)") },
            { "C", new ValueWithNote(null, "Curative (Retired 1 April 2018)") },
            { "D", new ValueWithNote(null, "Diagnostic (Retired 1 April 2018)") },
            { "N", new ValueWithNote(null, "Neoadjuvant (Retired 1 January 2013)") },
            { "S", new ValueWithNote(null, "Staging (Retired 1 April 2018)") },
            { "P", new ValueWithNote(null, "Palliative (Retired 1 April 2018)") },
            { "09", new ValueWithNote(null, "Not known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
