using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ConditionOccurrence.COSDv9CTConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 CT Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9CTConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9CTConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
