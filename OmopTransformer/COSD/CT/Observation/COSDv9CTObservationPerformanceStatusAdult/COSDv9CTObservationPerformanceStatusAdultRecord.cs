using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V9 CT Observation Performance Status Adult")]
[SourceQuery("COSDv9CTObservationPerformanceStatusAdult.xml")]
internal class COSDv9CTObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
