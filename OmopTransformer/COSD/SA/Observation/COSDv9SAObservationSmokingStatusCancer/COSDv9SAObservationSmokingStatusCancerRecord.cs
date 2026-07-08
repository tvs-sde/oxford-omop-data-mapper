using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv9SAObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 SA Observation Smoking Status Cancer")]
[SourceQuery("COSDv9SAObservationSmokingStatusCancer.xml")]
internal class COSDv9SAObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
