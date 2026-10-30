using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CO.ProcedureOccurrence.COSDv9COProcedureOccurrenceSmokingCessationTreatment;

/// <summary>
/// COSD V9 CO - Smoking Cessation Treatment
/// Maps smoking cessation treatments to OMOP procedure_occurrence
/// </summary>
internal class COSDv9COProcedureOccurrenceSmokingCessationTreatment : OmopProcedureOccurrence<COSDv9COProcedureOccurrenceSmokingCessationTreatmentRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.TobaccoSmokingCessation))]
    public override string? procedure_source_value { get; set; }

    [ConstantValue(46273821, "Smoking cessation therapy")]
    public override int[]? procedure_concept_id { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }
}
