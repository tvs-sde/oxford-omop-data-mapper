using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9TobaccoSmokingStatus;

[DataOrigin("COSD")]
[Description("CosdV9TobaccoSmokingStatus")]
[SourceQuery("CosdV9TobaccoSmokingStatus.xml")]
internal class CosdV9TobaccoSmokingStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? TobaccoSmokingStatus { get; set; }
}
