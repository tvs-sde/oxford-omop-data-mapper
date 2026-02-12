using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ADULT COMORBIDITY EVALUATION - 27 SCORE")]
internal class AdultComorbidityEvaluation27ScoreLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "0", new ValueWithNote(null, "None") },
            { "1", new ValueWithNote(null, "Mild") },
            { "2", new ValueWithNote(null, "Moderate") },
            { "3", new ValueWithNote(null, "Severe") },
            { "9", new ValueWithNote(null, "Not Known (Not recorded or test not done)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
