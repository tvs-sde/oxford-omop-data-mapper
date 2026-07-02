using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv9GYObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V9 GY Observation Performance Status Adult")]
[SourceQuery("COSDv9GYObservationPerformanceStatusAdult.xml")]
internal class COSDv9GYObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
