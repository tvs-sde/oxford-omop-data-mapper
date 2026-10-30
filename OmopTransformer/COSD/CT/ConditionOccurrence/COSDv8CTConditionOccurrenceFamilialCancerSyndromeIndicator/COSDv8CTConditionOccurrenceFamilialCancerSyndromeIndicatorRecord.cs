using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ConditionOccurrence.COSDv8CTConditionOccurrenceFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 CT Condition Occurrence Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8CTConditionOccurrenceFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8CTConditionOccurrenceFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
