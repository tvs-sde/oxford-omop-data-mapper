using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BR.ConditionOccurrence.CosdV8BreastConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("CosdV8BreastConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class CosdV8BreastConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? FamilialCancerSyndromeIndicator { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
