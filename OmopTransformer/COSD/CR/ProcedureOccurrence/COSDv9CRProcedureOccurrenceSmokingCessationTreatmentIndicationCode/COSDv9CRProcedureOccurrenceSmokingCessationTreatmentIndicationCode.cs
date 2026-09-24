using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CR.ProcedureOccurrence.COSDv9CRProcedureOccurrenceSmokingCessationTreatmentIndicationCode;

/// <summary>
/// COSD V9 CR - Smoking Cessation Treatment Indication Code
/// Maps smoking cessation treatments to OMOP procedure_occurrence
/// </summary>
internal class COSDv9CRProcedureOccurrenceSmokingCessationTreatmentIndicationCode : OmopProcedureOccurrence<COSDv9CRProcedureOccurrenceSmokingCessationTreatmentIndicationCodeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.TobaccoSmokingCessationTreatmentIndicationCode))]
    public override string? procedure_source_value { get; set; }

    [ConstantValue(46273821, "Smoking cessation therapy")]
    public override int[]? procedure_concept_id { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }
}
