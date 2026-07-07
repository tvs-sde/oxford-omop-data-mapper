using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv9HAObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 HA Observation Smoking Status Cancer")]
[SourceQuery("COSDv9HAObservationSmokingStatusCancer.xml")]
internal class COSDv9HAObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
