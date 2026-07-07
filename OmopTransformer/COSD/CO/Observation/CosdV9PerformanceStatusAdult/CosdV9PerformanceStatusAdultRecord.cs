using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9PerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("CosdV9PerformanceStatusAdult")]
[SourceQuery("CosdV9PerformanceStatusAdult.xml")]
internal class CosdV9PerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
