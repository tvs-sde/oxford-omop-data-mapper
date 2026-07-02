using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 HA Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8HAObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8HAObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
