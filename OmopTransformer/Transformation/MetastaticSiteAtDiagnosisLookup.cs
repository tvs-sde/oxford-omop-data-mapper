using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("METASTATIC SITE (AT DIAGNOSIS)")]
internal class MetastaticSiteAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Bone (Retired 1 July 2012)") },
            { "02", new ValueWithNote(null, "Brain") },
            { "03", new ValueWithNote(null, "Liver") },
            { "04", new ValueWithNote(null, "Lung") },
            { "05", new ValueWithNote(null, "Other metastatic site (Retired 1 July 2012)") },
            { "06", new ValueWithNote(null, "Multiple metastatic sites (Retired 1 April 2018)") },
            { "07", new ValueWithNote(null, "Unknown metastatic site") },
            { "08", new ValueWithNote(null, "Skin") },
            { "09", new ValueWithNote(null, "Distant Lymph Nodes") },
            { "10", new ValueWithNote(null, "Bone (excluding Bone Marrow)") },
            { "11", new ValueWithNote(null, "Bone marrow") },
            { "12", new ValueWithNote(null, "Regional Lymph Nodes") },
            { "98", new ValueWithNote(null, "Other metastatic site (not listed)") },
            { "99", new ValueWithNote(null, "Other metastatic site (Retired 1 April 2018)") },
            { "97", new ValueWithNote(null, "Not Applicable (Disease not spread)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
