using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SURGICAL ACCESS TYPE")]
internal class SurgicalAccessTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Open Surgery") },
            { "2", new ValueWithNote(null, "Laparoscopic/Thoracoscopic with planned conversion to open surgery") },
            { "3", new ValueWithNote(null, "Laparoscopic/Thoracoscopic with unplanned conversion to open surgery") },
            { "4", new ValueWithNote(null, "Laparoscopic/Thoracoscopic completed") },
            { "5", new ValueWithNote(null, "Robotic surgery") },
            { "Z", new ValueWithNote(null, "Surgical Access Not Applicable") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}