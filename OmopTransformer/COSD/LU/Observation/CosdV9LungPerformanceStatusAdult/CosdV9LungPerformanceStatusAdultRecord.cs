using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungPerformanceStatusAdult;

[DataOrigin("COSD")]
[Description("CosdV9LungPerformanceStatusAdult")]
[SourceQuery("CosdV9LungPerformanceStatusAdult.xml")]
internal class CosdV9LungPerformanceStatusAdultRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? PerformanceStatusAdult { get; set; }
}
