using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv9HNProcedureOccurrenceDiagnosticProcedureSNOMEDCT;

internal class COSDv9HNProcedureOccurrenceDiagnosticProcedureSNOMEDCT : OmopProcedureOccurrence<COSDv9HNProcedureOccurrenceDiagnosticProcedureSNOMEDCTRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DiagnosticProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DiagnosticProcedureDate))]
    public override DateTime? procedure_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? procedure_type_concept_id { get; set; }

    [Transform(typeof(SnomedSelector), nameof(Source.DiagnosticProcedureSnomedCt))]
    public override int? procedure_source_concept_id { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [CopyValue(nameof(Source.DiagnosticProcedureSnomedCt))]
    public override string? procedure_source_value { get; set; }
}
