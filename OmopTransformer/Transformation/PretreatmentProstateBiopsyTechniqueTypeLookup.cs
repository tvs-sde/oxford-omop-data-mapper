using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PRETREATMENT PROSTATE BIOPSY TECHNIQUE TYPE")]
internal class PretreatmentProstateBiopsyTechniqueTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Transrectal sampling biopsy (Retired 1 April 2020)") },
            { "2", new ValueWithNote(null, "Transrectal saturation biopsy (Retired 1 April 2020)") },
            { "3", new ValueWithNote(null, "Perineal sampling biopsy (Retired 1 April 2020)") },
            { "4", new ValueWithNote(null, "Perineal template mapping biopsy (Retired 1 April 2020)") },
            { "8", new ValueWithNote(null, "Other biopsy (not listed) (Retired 1 April 2020)") },
            { "10", new ValueWithNote(null, "Transrectal ultrasound (TRUS) guided biopsy (standard)") },
            { "11", new ValueWithNote(null, "Transrectal ultrasound (TRUS) guided biopsy (targeted)") },
            { "12", new ValueWithNote(null, "Transrectal ultrasound (TRUS) guided biopsy (targeted and standard)") },
            { "13", new ValueWithNote(null, "Transperineal biopsy (systematic)") },
            { "14", new ValueWithNote(null, "Transperineal biopsy (targeted)") },
            { "15", new ValueWithNote(null, "Transperineal biopsy (targeted and systematic)") },
            { "7", new ValueWithNote(null, "Not applicable (no biopsy done) (Retired 1 April 2020)") },
            { "9", new ValueWithNote(null, "Not known (not recorded) (Retired 1 April 2020)") },
            { "99", new ValueWithNote(null, "Not known (not recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
