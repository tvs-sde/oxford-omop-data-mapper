using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungAsaScore;

[DataOrigin("COSD")]
[Description("CosdV9LungAsaScore")]
[SourceQuery("CosdV9LungAsaScore.xml")]
internal class CosdV9LungAsaScoreRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
