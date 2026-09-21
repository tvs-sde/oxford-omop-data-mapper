using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV9ConditionOccurrenceMenopausalStatus;

internal class CosdV9ConditionOccurrenceMenopausalStatus : OmopConditionOccurrence<CosdV9ConditionOccurrenceMenopausalStatusRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(MenopausalStatusLookup), nameof(Source.MenopausalStatus))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.MenopausalStatus))]
    public override string? condition_source_value { get; set; }
}
