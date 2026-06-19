using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungHistoryOfAlcoholPast;

[DataOrigin("COSD")]
[Description("CosdV9LungHistoryOfAlcoholPast")]
[SourceQuery("CosdV9LungHistoryOfAlcoholPast.xml")]
internal class CosdV9LungHistoryOfAlcoholPastRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? HistoryOfAlcoholPast { get; set; }
}
