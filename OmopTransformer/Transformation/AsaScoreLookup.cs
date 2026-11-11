using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup ASA score concept.")]
internal class AsaScoreLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("653309", "ASA I (A normal healthy patient)") },
            { "2", new ValueWithNote("652943", "ASA II (Mild systemic disease)") },
            { "3", new ValueWithNote("654324", "ASA III (A patient with severe systemic disease)") },
            { "4", new ValueWithNote("652750", "ASA IV (A patient with severe systemic disease that is a constant threat to life)") },
            { "5", new ValueWithNote("652861", "ASA V (A moribund patient who is not expected to survive without the operation)") },
            { "6", new ValueWithNote("", "Unmapped") },
        };

    public string[] ColumnNotes =>
    [
        "[ASA Score](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---treatment"
    ];
}