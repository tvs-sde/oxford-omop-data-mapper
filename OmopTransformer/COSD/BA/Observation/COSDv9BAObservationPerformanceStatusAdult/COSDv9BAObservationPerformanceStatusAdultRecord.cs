using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Observation.COSDv9BAObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V9 BA Observation Performance Status Adult")]
[SourceQuery("COSDv9BAObservationPerformanceStatusAdult.xml")]
internal class COSDv9BAObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
