using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv8URObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 UR Observation Smoking Status Cancer")]
[SourceQuery("COSDv8URObservationSmokingStatusCancer.xml")]
internal class COSDv8URObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
