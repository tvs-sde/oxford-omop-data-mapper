using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup cancer intent concept.")]
internal class CancerIntentLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote("4162591", "Curative") },
            { "02", new ValueWithNote("4179711", "Palliative") },
            { "03", new ValueWithNote("44811666", "Disease Modification") },
            { "04", new ValueWithNote("4129646", "Diagnostic") },
            { "05", new ValueWithNote("4190468", "Staging") },
            { "06", new ValueWithNote("",     "Uncertain of Treatment Intent - No mapping possible") },
            { "09", new ValueWithNote("",     "Not Known - No mapping possible") },
            { "98", new ValueWithNote("",     "Other - No mapping possible") }
        };

    public string[] ColumnNotes =>
    [
        "[Cancer Treatment Intent](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---treatment"
    ];
}