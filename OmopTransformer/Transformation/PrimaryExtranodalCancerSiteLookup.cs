using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PRIMARY EXTRANODAL CANCER SITE")]
internal class PrimaryExtranodalCancerSiteLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Blood") },
            { "02", new ValueWithNote(null, "Bone") },
            { "03", new ValueWithNote(null, "CNS (Central Nervous System)") },
            { "04", new ValueWithNote(null, "GIT (Gastrointestinal Tract)") },
            { "05", new ValueWithNote(null, "GU (Genitourinary)") },
            { "06", new ValueWithNote(null, "Liver") },
            { "07", new ValueWithNote(null, "Marrow") },
            { "08", new ValueWithNote(null, "Muscle") },
            { "09", new ValueWithNote(null, "Orbit") },
            { "10", new ValueWithNote(null, "Pericardium") },
            { "11", new ValueWithNote(null, "Pulmonary") },
            { "12", new ValueWithNote(null, "Salivary gland") },
            { "13", new ValueWithNote(null, "Skin") },
            { "14", new ValueWithNote(null, "Thyroid") },
            { "15", new ValueWithNote(null, "Other (not listed)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
