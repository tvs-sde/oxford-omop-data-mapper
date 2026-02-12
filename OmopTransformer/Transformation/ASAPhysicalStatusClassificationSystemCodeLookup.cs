using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ASA PHYSICAL STATUS CLASSIFICATION SYSTEM CODE")]
internal class ASAPhysicalStatusClassificationSystemCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "A normal healthy patient") },
            { "2", new ValueWithNote(null, "A patient with mild systemic disease") },
            { "3", new ValueWithNote(null, "A patient with severe systemic disease") },
            { "4", new ValueWithNote(null, "A patient with severe systemic disease that is a constant threat to life") },
            { "5", new ValueWithNote(null, "A moribund patient who is not expected to survive without the operation") },
            { "6", new ValueWithNote(null, "A declared brain-dead patient whose organs are being removed for donor purposes") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
