using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8FamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("CosdV8FamilialCancerSyndromeIndicator")]
[SourceQuery("CosdV8FamilialCancerSyndromeIndicator.xml")]
internal class CosdV8FamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
