using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("CosdV8LungFamilialCancerSyndromeIndicator")]
[SourceQuery("CosdV8LungFamilialCancerSyndromeIndicator.xml")]
internal class CosdV8LungFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
