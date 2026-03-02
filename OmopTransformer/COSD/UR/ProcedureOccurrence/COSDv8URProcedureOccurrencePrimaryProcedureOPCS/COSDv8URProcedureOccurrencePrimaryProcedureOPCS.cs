using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.UR.ProcedureOccurrence.COSDv8URProcedureOccurrencePrimaryProcedureOPCS;

internal class COSDv8URProcedureOccurrencePrimaryProcedureOPCS : OmopProcedureOccurrence<COSDv8URProcedureOccurrencePrimaryProcedureOPCSRecord>
{
    [CopyValue(nameof(Source.NHSNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [ConstantValue(32879, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.PrimaryProcedureOPCS))]
    public override int? procedure_source_concept_id { get; set; }

    [CopyValue(nameof(Source.PrimaryProcedureOPCS))]
    public override string? procedure_source_value { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }
}
