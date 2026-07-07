using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Observation.COSDv9LVObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V9 LV Observation Performance Status Adult")]
[SourceQuery("COSDv9LVObservationPerformanceStatusAdult.xml")]
internal class COSDv9LVObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
