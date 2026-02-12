using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CANCER TREATMENT EVENT TYPE")]
internal class CancerTreatmentEventTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "First definitive treatment for a new primary cancer") },
            { "02", new ValueWithNote(null, "Second or subsequent treatment for a new primary cancer") },
            { "03", new ValueWithNote(null, "Treatment for a local recurrence of a primary cancer") },
            { "04", new ValueWithNote(null, "Treatment for a regional recurrence of cancer") },
            { "05", new ValueWithNote(null, "Treatment for a distant recurrence of cancer (metastatic disease)") },
            { "06", new ValueWithNote(null, "Treatment for multiple recurrence of cancer (local and/or regional and/or distant)") },
            { "07", new ValueWithNote(null, "First treatment for metastatic disease following an unknown primary cancer") },
            { "08", new ValueWithNote(null, "Second or subsequent treatment for metastatic disease following an unknown primary cancer") },
            { "09", new ValueWithNote(null, "Treatment for relapse of primary cancer (second or subsequent)") },
            { "10", new ValueWithNote(null, "Treatment for cancer progression of primary cancer (second or subsequent)") },
            { "11", new ValueWithNote(null, "Treatment for cancer transformation of primary cancer (second or subsequent)") },
            { "12", new ValueWithNote(null, "First treatment for metastatic disease following a known primary cancer") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
