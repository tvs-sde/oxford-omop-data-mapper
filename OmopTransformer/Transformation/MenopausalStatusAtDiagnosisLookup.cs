using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("MENOPAUSAL STATUS (AT DIAGNOSIS)")]
internal class MenopausalStatusAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Premenopausal") },
            { "2", new ValueWithNote(null, "Perimenopausal") },
            { "3", new ValueWithNote(null, "Postmenopausal") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
