using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv8HNObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 HN Observation Smoking Status Cancer")]
[SourceQuery("COSDv8HNObservationSmokingStatusCancer.xml")]
internal class COSDv8HNObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
