using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("LUNG METASTASES SUB-STAGE GROUPING")]
internal class LungMetastasesSubStageGroupingLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "L1", new ValueWithNote(null, "Less than or equal to 3 metastases") },
            { "L2", new ValueWithNote(null, "Greater than 3 metastases") },
            { "L3", new ValueWithNote(null, "Greater than 3 metastases, one or more greater than or equal to 2cm diameter") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
