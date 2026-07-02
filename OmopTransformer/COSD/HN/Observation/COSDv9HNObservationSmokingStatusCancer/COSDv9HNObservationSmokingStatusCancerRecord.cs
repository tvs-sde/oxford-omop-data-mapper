using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv9HNObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 HN Observation Smoking Status Cancer")]
[SourceQuery("COSDv9HNObservationSmokingStatusCancer.xml")]
internal class COSDv9HNObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
