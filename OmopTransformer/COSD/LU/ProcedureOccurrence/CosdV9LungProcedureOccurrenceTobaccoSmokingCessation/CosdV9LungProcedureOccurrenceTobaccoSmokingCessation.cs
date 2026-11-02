using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.LU.ProcedureOccurrence.CosdV9LungProcedureOccurrenceTobaccoSmokingCessation;

/// <summary>
/// COSD V9 LU - Tobacco Smoking Cessation
/// Maps tobacco smoking cessation treatments to OMOP procedure_occurrence
/// </summary>
internal class CosdV9LungProcedureOccurrenceTobaccoSmokingCessation : OmopProcedureOccurrence<CosdV9LungProcedureOccurrenceTobaccoSmokingCessationRecord>
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
