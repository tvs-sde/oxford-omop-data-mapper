using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungHistoryOfAlcoholCurrent;

[DataOrigin("COSD")]
[Description("CosdV9LungHistoryOfAlcoholCurrent")]
[SourceQuery("CosdV9LungHistoryOfAlcoholCurrent.xml")]
internal class CosdV9LungHistoryOfAlcoholCurrentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? HistoryOfAlcoholCurrent { get; set; }
}
