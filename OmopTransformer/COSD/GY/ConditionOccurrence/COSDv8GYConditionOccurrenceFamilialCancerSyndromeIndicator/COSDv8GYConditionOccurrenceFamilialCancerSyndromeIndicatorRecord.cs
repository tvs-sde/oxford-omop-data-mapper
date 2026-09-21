using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv8GYConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 GY Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8GYConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8GYConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
