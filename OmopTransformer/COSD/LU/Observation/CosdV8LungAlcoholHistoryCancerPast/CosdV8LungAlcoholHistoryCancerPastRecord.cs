using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Observation.CosdV8LungAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("CosdV8LungAlcoholHistoryCancerPast")]
[SourceQuery("CosdV8LungAlcoholHistoryCancerPast.xml")]
internal class CosdV8LungAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
