using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastAsaScore;

[DataOrigin("COSD")]
[Description("CosdV9BreastAsaScore")]
[SourceQuery("CosdV9BreastAsaScore.xml")]
internal class CosdV9BreastAsaScoreRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AsaScore { get; set; }
}
