using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Observation.CosdV8LungAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("CosdV8LungAlcoholHistoryCancerInLastThreeMonths")]
[SourceQuery("CosdV8LungAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class CosdV8LungAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
