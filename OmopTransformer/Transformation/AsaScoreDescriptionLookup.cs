using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup ASA score description concept.")]
internal class AsaScoreDescriptionLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("653309", "ASA 1 - A normal healthy patient.") },
            { "2", new ValueWithNote("652943", "ASA 2 - A patient with mild systemic disease.") },
            { "3", new ValueWithNote("654324", "ASA 3 - A patient with severe systemic disease.") },
            { "4", new ValueWithNote("652750", "ASA 4 - A patient with poorly controlled systemic disease.") },
            { "5", new ValueWithNote("652861", "ASA 5 - A patient with a moribund condition that is not expected to survive without the operation.") },
            { "6", new ValueWithNote("", "ASA 6 - A declared brain-dead patient whose organs are being removed for donor purposes") },
        };

    public string[] ColumnNotes =>
    [
        "[ASA Score](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---treatment"
    ];
}