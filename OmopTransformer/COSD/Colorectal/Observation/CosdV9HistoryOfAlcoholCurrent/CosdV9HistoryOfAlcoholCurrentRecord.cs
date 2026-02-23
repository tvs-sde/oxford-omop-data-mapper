using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9HistoryOfAlcoholCurrent;

[DataOrigin("COSD")]
[Description("CosdV9HistoryOfAlcoholCurrent")]
[SourceQuery("CosdV9HistoryOfAlcoholCurrent.xml")]
internal class CosdV9HistoryOfAlcoholCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? Date { get; set; }
    public string? HistoryOfAlcoholCurrent { get; set; }
}
