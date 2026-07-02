using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv9SKObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 SK Observation Smoking Status Cancer")]
[SourceQuery("COSDv9SKObservationSmokingStatusCancer.xml")]
internal class COSDv9SKObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
