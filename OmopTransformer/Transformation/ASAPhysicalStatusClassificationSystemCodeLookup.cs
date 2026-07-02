using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ASA PHYSICAL STATUS CLASSIFICATION SYSTEM CODE")]
internal class ASAPhysicalStatusClassificationSystemCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("4320556", "A normal healthy patient") },
            { "2", new ValueWithNote("4320557", "A patient with mild systemic disease") },
            { "3", new ValueWithNote("4320729", "A patient with severe systemic disease") },
            { "4", new ValueWithNote("4320558", "A patient with severe systemic disease that is a constant threat to life") },
            { "5", new ValueWithNote("4320730", "A moribund patient who is not expected to survive without the operation") },
            { "6", new ValueWithNote("4320851", "A declared brain-dead patient whose organs are being removed for donor purposes") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}

