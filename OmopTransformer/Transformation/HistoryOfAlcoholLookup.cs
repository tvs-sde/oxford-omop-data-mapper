using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup history of alcohol concept.")]
internal class HistoryOfAlcoholLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("4336673", "Heavy drinker") },
            { "2", new ValueWithNote("4042862", "Light drinker") },
            { "3", new ValueWithNote("4022664", "Non - drinker") },
            { "Z", new ValueWithNote("", "Not Stated (patient asked but declined to provide a response)") },
            { "9", new ValueWithNote("", "Not Known (Not recorded)") }
        };

    public string[] ColumnNotes =>
    [
        "[History of Alcohol](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---clinical-nurse-specialist)"
    ];
}