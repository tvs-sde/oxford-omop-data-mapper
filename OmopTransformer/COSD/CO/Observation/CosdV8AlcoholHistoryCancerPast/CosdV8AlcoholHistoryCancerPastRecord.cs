using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8AlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("CosdV8AlcoholHistoryCancerPast")]
[SourceQuery("CosdV8AlcoholHistoryCancerPast.xml")]
internal class CosdV8AlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
