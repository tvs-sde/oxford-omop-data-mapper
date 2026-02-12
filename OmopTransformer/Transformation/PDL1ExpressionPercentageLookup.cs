using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PD-L1 EXPRESSION PERCENTAGE")]
internal class PDL1ExpressionPercentageLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "2", new ValueWithNote(null, "Less than 1%") },
            { "3", new ValueWithNote(null, "1% - 50%") },
            { "4", new ValueWithNote(null, "Greater than 50%") },
            { "5", new ValueWithNote(null, "Indeterminate/Test Failed") },
            { "1", new ValueWithNote(null, "Not Tested") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
