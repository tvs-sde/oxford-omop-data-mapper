using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CYTOGENETIC RISK GROUP (PAEDIATRIC MOLECULAR GENETIC ABNORMALITIES)")]
internal class CytogeneticRiskGroupPaediatricMolecularGeneticAbnormalitiesLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Good Risk") },
            { "2", new ValueWithNote(null, "Intermediate Risk") },
            { "3", new ValueWithNote(null, "Poor Risk") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
