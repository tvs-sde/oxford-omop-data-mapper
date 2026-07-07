using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8AlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("CosdV8AlcoholHistoryCancerInLastThreeMonths")]
[SourceQuery("CosdV8AlcoholHistoryCancerInLastThreeMonths.xml")]
internal class CosdV8AlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
