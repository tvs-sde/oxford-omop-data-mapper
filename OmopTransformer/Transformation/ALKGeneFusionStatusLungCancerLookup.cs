using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ALK GENE FUSION STATUS (LUNG CANCER)")]
internal class ALKGeneFusionStatusLungCancerLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Positive") },
            { "2", new ValueWithNote(null, "Negative") },
            { "3", new ValueWithNote(null, "Indeterminate / Test Failed") },
            { "8", new ValueWithNote(null, "Not Applicable (Not Tested)") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
