using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ConditionOccurrence.COSDv9HNConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 HN Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9HNConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9HNConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
