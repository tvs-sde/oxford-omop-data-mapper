using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("BRONCHOSCOPY PERFORMED TYPE")]
internal class BronchoscopyPerformedTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Flexible bronchoscopy") },
            { "2", new ValueWithNote(null, "Rigid bronchoscopy") },
            { "3", new ValueWithNote(null, "Endobronchial Ultrasound (EBUS) - Diagnostic") },
            { "4", new ValueWithNote(null, "Endobronchial Ultrasound (EBUS) - Staging") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
