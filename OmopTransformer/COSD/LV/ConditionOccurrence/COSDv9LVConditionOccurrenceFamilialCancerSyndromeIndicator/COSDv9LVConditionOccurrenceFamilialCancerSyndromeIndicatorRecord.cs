using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ConditionOccurrence.COSDv9LVConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 LV Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9LVConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9LVConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
