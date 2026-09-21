using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV8ConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("CosdV8ConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class CosdV8ConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
