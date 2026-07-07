using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv8GYObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 GY Observation Smoking Status Cancer")]
[SourceQuery("COSDv8GYObservationSmokingStatusCancer.xml")]
internal class COSDv8GYObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
