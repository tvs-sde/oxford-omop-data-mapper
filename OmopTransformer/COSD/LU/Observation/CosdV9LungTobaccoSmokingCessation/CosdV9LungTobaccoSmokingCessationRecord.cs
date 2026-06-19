using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungTobaccoSmokingCessation;

[DataOrigin("COSD")]
[Description("CosdV9LungTobaccoSmokingCessation")]
[SourceQuery("CosdV9LungTobaccoSmokingCessation.xml")]
internal class CosdV9LungTobaccoSmokingCessationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? TobaccoSmokingCessation { get; set; }
}
