using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv8HNObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V8 HN Observation Performance Status Adult")]
[SourceQuery("COSDv8HNObservationPerformanceStatusAdult.xml")]
internal class COSDv8HNObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
