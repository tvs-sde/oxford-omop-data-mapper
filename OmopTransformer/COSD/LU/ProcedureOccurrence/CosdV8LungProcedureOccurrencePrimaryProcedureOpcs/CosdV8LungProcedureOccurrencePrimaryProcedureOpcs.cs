using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrencePrimaryProcedureOpcs;

[Notes(
    "Assumptions",
    "* Primary procedure OPCS codes from lung cancer treatment records",
    "* Procedure dates are taken as recorded in the clinical system",
    "* Duplicates are handled by selecting distinct records based on NHS Number, Procedure Date, and Primary Procedure OPCS")]
internal class CosdV8LungProcedureOccurrencePrimaryProcedureOpcs : OmopProcedureOccurrence<CosdV8LungProcedureOccurrencePrimaryProcedureOpcsRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.PrimaryProcedureOpcs))]
    public override int? procedure_source_concept_id { set; get; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_datetime { get; set; }
    
    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }

    [CopyValue(nameof(Source.PrimaryProcedureOpcs))]
    public override string? procedure_source_value { get; set; }

    [ConstantValue(1, "One")]
    public override int? quantity { get; set; }
}