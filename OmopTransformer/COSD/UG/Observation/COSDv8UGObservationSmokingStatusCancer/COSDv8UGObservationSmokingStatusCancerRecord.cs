using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv8UGObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 UG Observation Smoking Status Cancer")]
[SourceQuery("COSDv8UGObservationSmokingStatusCancer.xml")]
internal class COSDv8UGObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
