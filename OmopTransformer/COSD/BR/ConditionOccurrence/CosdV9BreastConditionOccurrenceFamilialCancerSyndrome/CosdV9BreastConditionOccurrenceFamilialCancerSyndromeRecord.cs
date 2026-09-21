using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BR.ConditionOccurrence.CosdV9BreastConditionOccurrenceFamilialCancerSyndrome;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Condition Occurrence Familial Cancer Syndrome")]
[SourceQuery("CosdV9BreastConditionOccurrenceFamilialCancerSyndrome.xml")]
internal class CosdV9BreastConditionOccurrenceFamilialCancerSyndromeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndrome { get; set; }
}
