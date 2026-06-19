using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9TobaccoSmokingCessation;

[DataOrigin("COSD")]
[Description("CosdV9TobaccoSmokingCessation")]
[SourceQuery("CosdV9TobaccoSmokingCessation.xml")]
internal class CosdV9TobaccoSmokingCessationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? TobaccoSmokingCessation { get; set; }
}
