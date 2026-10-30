using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ConditionOccurrence.COSDv8HNConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 HN Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8HNConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8HNConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
