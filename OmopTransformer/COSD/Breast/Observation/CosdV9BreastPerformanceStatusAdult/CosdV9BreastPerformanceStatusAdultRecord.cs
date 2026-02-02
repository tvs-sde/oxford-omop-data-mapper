using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("CosdV9BreastPerformanceStatusAdult")]
[SourceQuery("CosdV9BreastPerformanceStatusAdult.xml")]
internal class CosdV9BreastPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
