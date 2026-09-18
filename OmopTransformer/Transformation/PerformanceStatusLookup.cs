using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup performance status concept.")]
internal class PerformanceStatusLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "0", new ValueWithNote("45881176", "Asymptomatic") },
            { "1", new ValueWithNote("45885272", "Symptomatic, full ADLS") },
            { "2", new ValueWithNote("45877958", "Symptomatic, in bed <50% day") },
            { "3", new ValueWithNote("45879697", "Symptomatic, in bed >50% day") },
            { "4", new ValueWithNote("45877743", "Bedridden") }
        };

    public string[] ColumnNotes =>
    [
        "[Performance Status](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---diagnosis)"
    ];
}