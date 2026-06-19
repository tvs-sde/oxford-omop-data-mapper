using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths")]
[SourceQuery("CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
