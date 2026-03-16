using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.UR.ProcedureOccurrence.COSDv9URProcedureOccurrenceProcedureOpcs;

internal class COSDv9URProcedureOccurrenceProcedureOpcs : OmopProcedureOccurrence<COSDv9URProcedureOccurrenceProcedureOpcsRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [ConstantValue(32879, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.ProcedureOpcs))]
    public override int? procedure_source_concept_id { get; set; }

    [CopyValue(nameof(Source.ProcedureOpcs))]
    public override string? procedure_source_value { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }
}
