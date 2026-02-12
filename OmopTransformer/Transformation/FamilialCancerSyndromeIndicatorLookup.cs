using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("FAMILIAL CANCER SYNDROME INDICATOR")]
internal class FamilialCancerSyndromeIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - there is a confirmed familial cancer syndrome") },
            { "N", new ValueWithNote(null, "No - there is no confirmed familial cancer syndrome") },
            { "P", new ValueWithNote(null, "Possible familial cancer syndrome") },
            { "9", new ValueWithNote(null, "Not Known (Not recorded or test not done)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
