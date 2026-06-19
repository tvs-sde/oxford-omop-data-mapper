using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungTobaccoSmokingStatus;

[DataOrigin("COSD")]
[Description("CosdV9LungTobaccoSmokingStatus")]
[SourceQuery("CosdV9LungTobaccoSmokingStatus.xml")]
internal class CosdV9LungTobaccoSmokingStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? TobaccoSmokingStatus { get; set; }
}
