using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS)")]
internal class PersonStatedSexualOrientationCodeAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("4069091", "Heterosexual or Straight") },
            { "2", new ValueWithNote("444056", "Gay or Lesbian") },
            { "3", new ValueWithNote("4170582", "Bisexual") },
            { "4", new ValueWithNote("4260977", "Other sexual orientation not listed") },
            { "U", new ValueWithNote("42689512", "Person asked and does not know or is not sure") },
            { "Z", new ValueWithNote("4260977", "Not Stated (person asked but declined to provide a response)") },
            { "9", new ValueWithNote("4260977", "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}

