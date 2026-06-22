using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BR.ConditionOccurrence.CosdV9BreastConditionOccurrenceProgression;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Condition Occurrence Progression")]
[SourceQuery("CosdV9BreastConditionOccurrenceProgression.xml")]
internal class CosdV9BreastConditionOccurrenceProgressionRecord
{
    public string? NhsNumber { get; set; }
    public string? NonPrimaryDiagnosisDate { get; set; }
    public string? NonPrimaryProgressionOriginalDiagnosis { get; set; }
}
