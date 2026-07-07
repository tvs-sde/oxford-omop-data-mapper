using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv9HNObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V9 HN Observation Performance Status Adult")]
[SourceQuery("COSDv9HNObservationPerformanceStatusAdult.xml")]
internal class COSDv9HNObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
