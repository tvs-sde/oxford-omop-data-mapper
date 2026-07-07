using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationSmokingStatusCancer;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Smoking Status Cancer")]
[SourceQuery("COSDv9CRObservationSmokingStatusCancer.xml")]
internal class COSDv9CRObservationSmokingStatusCancerRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SmokingStatusCancer { get; set; }
}
