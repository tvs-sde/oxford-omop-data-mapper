using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CT.ProcedureOccurrence.COSDv901CTProcedureOccurrenceDiagnosticProcedureSnomedCt;

/// <summary>
/// COSD V901 CT - Diagnostic Procedures (SNOMED CT)
/// Maps diagnostic SNOMED CT coded procedures to OMOP procedure_occurrence
/// </summary>
internal class COSDv901CTProcedureOccurrenceDiagnosticProcedureSnomedCt : OmopProcedureOccurrence<COSDv901CTProcedureOccurrenceDiagnosticProcedureSnomedCtRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DiagnosticProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.DiagnosticProcedureSnomedCt))]
    public override string? procedure_source_value { get; set; }

    [Transform(typeof(SnomedSelector), nameof(Source.DiagnosticProcedureSnomedCt))]
    public override int? procedure_source_concept_id { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }
}
