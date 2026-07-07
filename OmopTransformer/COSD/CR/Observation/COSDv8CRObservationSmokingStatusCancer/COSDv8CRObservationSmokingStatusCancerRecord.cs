using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv8CRObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V8 CR Observation Smoking Status Cancer")]
[SourceQuery("COSDv8CRObservationSmokingStatusCancer.xml")]
internal class COSDv8CRObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
