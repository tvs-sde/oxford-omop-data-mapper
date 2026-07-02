using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Observation.COSDv8LVObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V8 LV Observation Performance Status Adult")]
[SourceQuery("COSDv8LVObservationPerformanceStatusAdult.xml")]
internal class COSDv8LVObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
