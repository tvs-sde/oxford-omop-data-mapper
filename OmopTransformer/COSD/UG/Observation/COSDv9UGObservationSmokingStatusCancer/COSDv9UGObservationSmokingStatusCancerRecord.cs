using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv9UGObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 UG Observation Smoking Status Cancer")]
[SourceQuery("COSDv9UGObservationSmokingStatusCancer.xml")]
internal class COSDv9UGObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
