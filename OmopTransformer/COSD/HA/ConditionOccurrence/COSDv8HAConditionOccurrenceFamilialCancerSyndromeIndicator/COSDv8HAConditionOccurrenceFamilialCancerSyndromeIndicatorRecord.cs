using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.COSDv8HAConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 HA Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8HAConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8HAConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
