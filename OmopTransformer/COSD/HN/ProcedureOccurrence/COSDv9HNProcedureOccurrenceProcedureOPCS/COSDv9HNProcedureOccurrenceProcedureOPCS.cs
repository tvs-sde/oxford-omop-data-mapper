using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv9HNProcedureOccurrenceProcedureOPCS;

internal class COSDv9HNProcedureOccurrenceProcedureOPCS : OmopProcedureOccurrence<COSDv9HNProcedureOccurrenceProcedureOPCSRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? procedure_type_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.ProcedureOpcs))]
    public override int? procedure_source_concept_id { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [CopyValue(nameof(Source.ProcedureOpcs))]
    public override string? procedure_source_value { get; set; }
}
