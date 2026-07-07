using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv8GYObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 GY Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8GYObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8GYObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
