using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV8BreastConditionOccurrenceProgression;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Condition Occurrence Progression")]
[SourceQuery("CosdV8BreastConditionOccurrenceProgression.xml")]
internal class CosdV8BreastConditionOccurrenceProgressionRecord
{
    public string? NhsNumber { get; set; }
    public string? NonPrimaryDiagnosisDate { get; set; }
    public string? NonPrimaryProgressionOriginalDiagnosis { get; set; }
}
