using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("LIFE THREATENING SYMPTOMS AT DIAGNOSIS INDICATOR (NEUROBLASTOMA)")]
internal class LifeThreateningSymptomsAtDiagnosisIndicatorNeuroblastomaLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - there were life threatening symptoms at patient diagnosis") },
            { "N", new ValueWithNote(null, "No - there were no life threatening symptoms at patient diagnosis") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
