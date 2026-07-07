using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Observation.COSDv9LVObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 LV Observation Smoking Status Cancer")]
[SourceQuery("COSDv9LVObservationSmokingStatusCancer.xml")]
internal class COSDv9LVObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
