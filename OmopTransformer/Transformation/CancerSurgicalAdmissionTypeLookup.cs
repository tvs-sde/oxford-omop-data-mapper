using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CANCER SURGICAL ADMISSION TYPE")]
internal class CancerSurgicalAdmissionTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Elective Admission") },
            { "2", new ValueWithNote(null, "Emergency Admission") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
