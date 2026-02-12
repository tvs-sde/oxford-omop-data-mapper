using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS)")]
internal class PersonStatedSexualOrientationCodeAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Heterosexual or Straight") },
            { "2", new ValueWithNote(null, "Gay or Lesbian") },
            { "3", new ValueWithNote(null, "Bisexual") },
            { "4", new ValueWithNote(null, "Other sexual orientation not listed") },
            { "U", new ValueWithNote(null, "Person asked and does not know or is not sure") },
            { "Z", new ValueWithNote(null, "Not Stated (person asked but declined to provide a response)") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
