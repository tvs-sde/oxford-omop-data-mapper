using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv9HAObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 HA Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9HAObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9HAObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
