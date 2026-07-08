using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv8SKObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 SK Observation Smoking Status Cancer")]
[SourceQuery("COSDv8SKObservationSmokingStatusCancer.xml")]
internal class COSDv8SKObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
