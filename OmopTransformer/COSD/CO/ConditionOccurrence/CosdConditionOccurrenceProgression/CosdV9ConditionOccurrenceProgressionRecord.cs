using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrenceProgression;

[DataOrigin("COSD")]
[Description("COSD V9 Condition Occurrence Progression")]
[SourceQuery("CosdV9ConditionOccurrenceProgression.xml")]
internal class CosdV9ConditionOccurrenceProgressionRecord
{
    public string? NhsNumber { get; set; }
    public string? NonPrimaryDiagnosisDate { get; set; }
    public string? NonPrimaryProgressionOriginalDiagnosis { get; set; }
}