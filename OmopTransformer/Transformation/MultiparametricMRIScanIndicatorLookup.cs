using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("MULTIPARAMETRIC MRI SCAN INDICATOR")]
internal class MultiparametricMRIScanIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - a multiparametric MRI scan was performed before biopsy") },
            { "N", new ValueWithNote(null, "No - a multiparametric MRI scan was not performed before biopsy") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
