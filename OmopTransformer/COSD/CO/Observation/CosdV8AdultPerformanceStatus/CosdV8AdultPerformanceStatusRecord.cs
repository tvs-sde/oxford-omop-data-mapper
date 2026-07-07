using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8AdultPerformanceStatus;

[DataOrigin("COSD")]
[Description("CosdV8AdultPerformanceStatus")]
[SourceQuery("CosdV8AdultPerformanceStatus.xml")]
internal class CosdV8AdultPerformanceStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AdultPerformanceStatus { get; set; }
}
