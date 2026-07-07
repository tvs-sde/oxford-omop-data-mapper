using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9CRObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9CRObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
