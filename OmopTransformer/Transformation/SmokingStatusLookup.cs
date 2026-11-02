using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup smoking status concept.")]
internal class SmokingStatusLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("36309332", "Current smoker") },
            { "2", new ValueWithNote("45883458", "Former smoker") },
            { "4", new ValueWithNote("45879404", "Never smoker") },
            { "9", new ValueWithNote("", "Unknown") },
        };

    public string[] ColumnNotes =>
    [
        "[Smoking Status](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---clinical-nurse-specialist)"
    ];
}