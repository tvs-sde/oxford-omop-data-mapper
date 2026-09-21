using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.ConditionOccurrence.CosdV8LungConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("CosdV8LungConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class CosdV8LungConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
