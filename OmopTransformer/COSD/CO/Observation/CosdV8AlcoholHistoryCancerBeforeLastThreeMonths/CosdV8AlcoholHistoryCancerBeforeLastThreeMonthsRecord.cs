using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8AlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("CosdV8AlcoholHistoryCancerBeforeLastThreeMonths")]
[SourceQuery("CosdV8AlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class CosdV8AlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
