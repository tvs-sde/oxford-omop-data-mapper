using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.ConditionOccurrence.CosdV9LungConditionOccurrenceFamilialCancerSyndrome;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Condition Occurrence Familial Cancer Syndrome")]
[SourceQuery("CosdV9LungConditionOccurrenceFamilialCancerSyndrome.xml")]
internal class CosdV9LungConditionOccurrenceFamilialCancerSyndromeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndrome { get; set; }
}
