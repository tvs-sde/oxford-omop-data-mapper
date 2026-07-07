using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv9GYObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 GY Observation Smoking Status Cancer")]
[SourceQuery("COSDv9GYObservationSmokingStatusCancer.xml")]
internal class COSDv9GYObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
