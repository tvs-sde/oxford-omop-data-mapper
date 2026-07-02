using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv8CRObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V8 CR Observation Performance Status Adult")]
[SourceQuery("COSDv8CRObservationPerformanceStatusAdult.xml")]
internal class COSDv8CRObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
