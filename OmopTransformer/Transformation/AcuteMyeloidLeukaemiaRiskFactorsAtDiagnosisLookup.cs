using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ACUTE MYELOID LEUKAEMIA RISK FACTORS (AT DIAGNOSIS)")]
internal class AcuteMyeloidLeukaemiaRiskFactorsAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Denovo") },
            { "2", new ValueWithNote(null, "High Risk Myelodysplastic Syndromes (MDS)") },
            { "3", new ValueWithNote(null, "Secondary Acute Myeloid Leukaemia (AML)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
