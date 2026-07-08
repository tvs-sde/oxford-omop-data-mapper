using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv8CTObservationPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("COSD V8 CT Observation Performance Status Adult")]
[SourceQuery("COSDv8CTObservationPerformanceStatusAdult.xml")]
internal class COSDv8CTObservationPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
