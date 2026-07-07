using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv8GYObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V8 GY Observation Performance Status Adult")]
[SourceQuery("COSDv8GYObservationPerformanceStatusAdult.xml")]
internal class COSDv8GYObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
