using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SNOMED VERSION (CANCER TRANSFORMATION)")]
internal class SnomedVersionCancerTransformationLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "SNOMED II") },
            { "02", new ValueWithNote(null, "SNOMED 3") },
            { "03", new ValueWithNote(null, "SNOMED 3.5") },
            { "04", new ValueWithNote(null, "SNOMED RT") },
            { "05", new ValueWithNote(null, "SNOMED CT") },
            { "99", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}