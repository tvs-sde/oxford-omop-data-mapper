using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv8HNProcedureOccurrenceDiagnosticProcedureOpcs;

/// <summary>
/// COSD V8 HN - Diagnostic Procedures
/// Maps diagnostic OPCS-4 coded procedures to OMOP procedure_occurrence
/// </summary>
internal class COSDv8HNProcedureOccurrenceDiagnosticProcedureOpcs : OmopProcedureOccurrence<COSDv8HNProcedureOccurrenceDiagnosticProcedureOpcsRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DiagnosticProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.DiagnosticProcedureOpcs))]
    public override string? procedure_source_value { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.DiagnosticProcedureOpcs))]
    public override int? procedure_source_concept_id { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }
}
