using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9HistoryOfAlcoholPast;

[DataOrigin("COSD")]
[Description("CosdV9HistoryOfAlcoholPast")]
[SourceQuery("CosdV9HistoryOfAlcoholPast.xml")]
internal class CosdV9HistoryOfAlcoholPastRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? HistoryOfAlcoholPast { get; set; }
}
