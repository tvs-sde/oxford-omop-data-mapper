using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("METASTATIC SITE (AT DIAGNOSIS)")]
internal class MetastaticSiteAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote("0", "Bone (Retired 1 July 2012)") },
            { "02", new ValueWithNote("0", "Brain") },
            { "03", new ValueWithNote("0", "Liver") },
            { "04", new ValueWithNote("0", "Lung") },
            { "05", new ValueWithNote("0", "Other metastatic site (Retired 1 July 2012)") },
            { "06", new ValueWithNote("0", "Multiple metastatic sites (Retired 1 April 2018)") },
            { "07", new ValueWithNote("0", "Unknown metastatic site") },
            { "08", new ValueWithNote("0", "Skin") },
            { "09", new ValueWithNote("0", "Distant Lymph Nodes") },
            { "10", new ValueWithNote("0", "Bone (excluding Bone Marrow)") },
            { "11", new ValueWithNote("0", "Bone marrow") },
            { "12", new ValueWithNote("0", "Regional Lymph Nodes") },
            { "98", new ValueWithNote("0", "Other metastatic site (not listed)") },
            { "99", new ValueWithNote("0", "Other metastatic site (Retired 1 April 2018)") },
            { "97", new ValueWithNote("0", "Not Applicable (Disease not spread)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
