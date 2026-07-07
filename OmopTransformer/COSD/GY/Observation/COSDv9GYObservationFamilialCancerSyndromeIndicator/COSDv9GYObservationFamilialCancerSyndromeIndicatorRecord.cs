using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv9GYObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 GY Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9GYObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9GYObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
