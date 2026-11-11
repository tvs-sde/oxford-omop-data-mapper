using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV9ConditionOccurrenceFamilialCancerSyndrome;

[DataOrigin("COSD")]
[Description("COSD V9 Condition Occurrence Familial Cancer Syndrome")]
[SourceQuery("CosdV9ConditionOccurrenceFamilialCancerSyndrome.xml")]
internal class CosdV9ConditionOccurrenceFamilialCancerSyndromeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndrome { get; set; }
}
