using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv9URObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 UR Observation Smoking Status Cancer")]
[SourceQuery("COSDv9URObservationSmokingStatusCancer.xml")]
internal class COSDv9URObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
