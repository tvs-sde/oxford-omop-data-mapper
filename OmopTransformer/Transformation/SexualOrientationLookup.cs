using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup sexual orientation concept.")]
internal class SexualOrientationLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("36310681", "Heterosexual") },
            { "2", new ValueWithNote("36303203", "Homosexual") },
            { "3", new ValueWithNote("36307527", "Bisexual") },
            { "4", new ValueWithNote("45878142", "Other") },
            { "U", new ValueWithNote("36308454", "Asked but unknown") },
            { "Z", new ValueWithNote("45877986", "Unknown") },
            { "9", new ValueWithNote("45877986", "Unknown") },
        };

    public string[] ColumnNotes =>
    [
        "[Sexual Orientation](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---demographics)"
    ];
}