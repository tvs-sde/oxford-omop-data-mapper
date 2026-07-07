using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Observation.COSDv8BAObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V8 BA Observation Performance Status Adult")]
[SourceQuery("COSDv8BAObservationPerformanceStatusAdult.xml")]
internal class COSDv8BAObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
