using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv8SAObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 SA Observation Smoking Status Cancer")]
[SourceQuery("COSDv8SAObservationSmokingStatusCancer.xml")]
internal class COSDv8SAObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
