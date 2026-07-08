using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv9HNProcedureOccurrenceDiagnosticProcedureOPCS;

internal class COSDv9HNProcedureOccurrenceDiagnosticProcedureOPCS : OmopProcedureOccurrence<COSDv9HNProcedureOccurrenceDiagnosticProcedureOPCSRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DiagnosticProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DiagnosticProcedureDate))]
    public override DateTime? procedure_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? procedure_type_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.DiagnosticProcedureOpcs))]
    public override int? procedure_source_concept_id { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [CopyValue(nameof(Source.DiagnosticProcedureOpcs))]
    public override string? procedure_source_value { get; set; }
}
