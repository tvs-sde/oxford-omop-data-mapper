using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 HA Observation Smoking Status Cancer")]
[SourceQuery("COSDv8HAObservationSmokingStatusCancer.xml")]
internal class COSDv8HAObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
