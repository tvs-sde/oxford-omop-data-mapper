using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ConditionOccurrence.COSDv9CRConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 CR Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9CRConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9CRConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
