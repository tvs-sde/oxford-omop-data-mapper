using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("STAGE GROUPING (TESTICULAR CANCER)")]
internal class StageGroupingTesticularCancerLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Stage 1") },
            { "1S", new ValueWithNote(null, "Stage 1S") },
            { "1M", new ValueWithNote(null, "Stage 1M") },
            { "2A", new ValueWithNote(null, "Stage 2A") },
            { "2B", new ValueWithNote(null, "Stage 2B") },
            { "2C", new ValueWithNote(null, "Stage 2C") },
            { "3A", new ValueWithNote(null, "Stage 3A") },
            { "3B", new ValueWithNote(null, "Stage 3B") },
            { "3C", new ValueWithNote(null, "Stage 3C") },
            { "4A", new ValueWithNote(null, "Stage 4A") },
            { "4B", new ValueWithNote(null, "Stage 4B") },
            { "4C", new ValueWithNote(null, "Stage 4C") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}