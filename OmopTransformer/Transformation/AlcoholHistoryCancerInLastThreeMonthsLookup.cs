using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)")]
internal class AlcoholHistoryCancerInLastThreeMonthsLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("4336673", "Heavy (greater than 14 units per week)") },
            { "2", new ValueWithNote("4042862", "Light (less than or equal to 14 units per week)") },
            { "3", new ValueWithNote("4022664", "None ever") },
            { "Z", new ValueWithNote("0", "Not Stated (patient asked but declined to provide a response)") },
            { "9", new ValueWithNote("0", "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}

