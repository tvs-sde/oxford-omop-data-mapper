using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BR.Observation.CosdV9BreastHistoryOfAlcoholPast;

[DataOrigin("COSD")]
[Description("CosdV9BreastHistoryOfAlcoholPast")]
[SourceQuery("CosdV9BreastHistoryOfAlcoholPast.xml")]
internal class CosdV9BreastHistoryOfAlcoholPastRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? HistoryOfAlcoholPast { get; set; }
}
