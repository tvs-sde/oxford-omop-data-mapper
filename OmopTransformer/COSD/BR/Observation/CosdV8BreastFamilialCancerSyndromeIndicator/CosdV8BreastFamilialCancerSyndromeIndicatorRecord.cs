using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV8BreastFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Familial Cancer Syndrome Indicator")]
[SourceQuery("CosdV8BreastFamilialCancerSyndromeIndicator.xml")]
internal class CosdV8BreastFamilialCancerSyndromeIndicatorRecord
{
    public string? FamilialCancerSyndromeIndicator { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
