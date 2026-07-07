using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv9HAObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V9 HA Observation Performance Status Adult")]
[SourceQuery("COSDv9HAObservationPerformanceStatusAdult.xml")]
internal class COSDv9HAObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
