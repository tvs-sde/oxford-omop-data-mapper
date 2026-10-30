using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Observation.CosdV8LungAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("CosdV8LungAlcoholHistoryCancerCurrent")]
[SourceQuery("CosdV8LungAlcoholHistoryCancerCurrent.xml")]
internal class CosdV8LungAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
