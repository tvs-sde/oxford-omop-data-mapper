using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)")]
internal class AlcoholHistoryCancerBeforeLastThreeMonthsLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Heavy (greater than 14 units per week)") },
            { "2", new ValueWithNote(null, "Light (less than or equal to 14 units per week)") },
            { "3", new ValueWithNote(null, "None ever") },
            { "Z", new ValueWithNote(null, "Not Stated (patient asked but declined to provide a response)") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
