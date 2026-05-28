using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("GRADE OF DIFFERENTIATION (AT DIAGNOSIS)")]
internal class GradeOfDifferentiationAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "G1", new ValueWithNote("0", "Well differentiated") },
            { "G2", new ValueWithNote("0", "Moderately differentiated") },
            { "G3", new ValueWithNote("0", "Poorly differentiated") },
            { "G4", new ValueWithNote("0", "Undifferentiated / anaplastic") },
            { "GX", new ValueWithNote("0", "Grade of differentiation is not appropriate or cannot be assessed") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
