using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Performance Status Adult")]
[SourceQuery("COSDv9CRObservationPerformanceStatusAdult.xml")]
internal class COSDv9CRObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
