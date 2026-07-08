using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv8CTObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 CT Observation Smoking Status Cancer")]
[SourceQuery("COSDv8CTObservationSmokingStatusCancer.xml")]
internal class COSDv8CTObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
