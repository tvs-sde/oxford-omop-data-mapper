using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;

namespace OmopTransformer.COSD.BR.ConditionOccurrence.CosdV9BreastConditionOccurrenceFamilialCancerSyndrome;

internal class CosdV9BreastConditionOccurrenceFamilialCancerSyndrome : OmopConditionOccurrence<CosdV9BreastConditionOccurrenceFamilialCancerSyndromeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? condition_type_concept_id { get; set; }

    [ConstantValue(2000500005, "Familial Cancer (Indicator)")]
    public override int? condition_source_concept_id { get; set; }

    [ConstantValue(44782478, "Hereditary cancer-predisposing syndrome")]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.FamilialCancerSyndrome))]
    public override string? condition_source_value { get; set; }
}
