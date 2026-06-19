using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastHistoryOfAlcoholCurrent;

[DataOrigin("COSD")]
[Description("CosdV9BreastHistoryOfAlcoholCurrent")]
[SourceQuery("CosdV9BreastHistoryOfAlcoholCurrent.xml")]
internal class CosdV9BreastHistoryOfAlcoholCurrentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? HistoryOfAlcoholCurrent { get; set; }
}
