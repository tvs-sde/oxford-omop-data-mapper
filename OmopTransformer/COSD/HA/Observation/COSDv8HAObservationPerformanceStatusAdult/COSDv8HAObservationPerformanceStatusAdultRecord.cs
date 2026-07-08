using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V8 HA Observation Performance Status Adult")]
[SourceQuery("COSDv8HAObservationPerformanceStatusAdult.xml")]
internal class COSDv8HAObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
