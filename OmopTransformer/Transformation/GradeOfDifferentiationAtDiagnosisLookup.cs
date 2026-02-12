using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("GRADE OF DIFFERENTIATION (AT DIAGNOSIS)")]
internal class GradeOfDifferentiationAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "G1", new ValueWithNote(null, "Well differentiated") },
            { "G2", new ValueWithNote(null, "Moderately differentiated") },
            { "G3", new ValueWithNote(null, "Poorly differentiated") },
            { "G4", new ValueWithNote(null, "Undifferentiated / anaplastic") },
            { "GX", new ValueWithNote(null, "Grade of differentiation is not appropriate or cannot be assessed") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
