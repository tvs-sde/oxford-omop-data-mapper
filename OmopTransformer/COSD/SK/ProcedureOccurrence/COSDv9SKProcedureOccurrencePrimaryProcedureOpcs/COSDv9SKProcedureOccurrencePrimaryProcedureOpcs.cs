using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.SK.ProcedureOccurrence.COSDv9SKProcedureOccurrencePrimaryProcedureOpcs;

/// <summary>
/// COSD V9 SK - Primary Surgical Procedures
/// Maps primary OPCS-4 coded procedures to OMOP procedure_occurrence
/// </summary>
internal class COSDv9SKProcedureOccurrencePrimaryProcedureOpcs : OmopProcedureOccurrence<COSDv9SKProcedureOccurrencePrimaryProcedureOpcsRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.PrimaryProcedureOpcs))]
    public override string? procedure_source_value { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.PrimaryProcedureOpcs))]
    public override int? procedure_source_concept_id { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }
}
