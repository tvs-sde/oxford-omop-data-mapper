using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 CT Observation Smoking Status Cancer")]
[SourceQuery("COSDv9CTObservationSmokingStatusCancer.xml")]
internal class COSDv9CTObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
