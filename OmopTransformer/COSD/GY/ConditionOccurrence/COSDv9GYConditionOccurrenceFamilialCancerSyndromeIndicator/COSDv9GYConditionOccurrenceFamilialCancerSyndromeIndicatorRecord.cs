using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv9GYConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 GY Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9GYConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9GYConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
