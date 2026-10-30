using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.COSDv9HAConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9HAConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9HAConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
