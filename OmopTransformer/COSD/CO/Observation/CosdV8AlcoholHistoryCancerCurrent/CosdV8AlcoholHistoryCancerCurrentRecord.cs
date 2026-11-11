using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8AlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("CosdV8AlcoholHistoryCancerCurrent")]
[SourceQuery("CosdV8AlcoholHistoryCancerCurrent.xml")]
internal class CosdV8AlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
