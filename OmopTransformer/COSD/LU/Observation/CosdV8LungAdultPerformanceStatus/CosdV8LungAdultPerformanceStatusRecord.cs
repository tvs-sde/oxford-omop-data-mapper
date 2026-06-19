using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungAdultPerformanceStatus;

[DataOrigin("COSD")]
[Description("CosdV8LungAdultPerformanceStatus")]
[SourceQuery("CosdV8LungAdultPerformanceStatus.xml")]
internal class CosdV8LungAdultPerformanceStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AdultPerformanceStatus { get; set; }
}
