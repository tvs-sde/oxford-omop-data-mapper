using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV9LungConditionOccurrenceProgression;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Condition Occurrence Progression")]
[SourceQuery("CosdV9LungConditionOccurrenceProgression.xml")]
internal class CosdV9LungConditionOccurrenceProgressionRecord
{
    public string? NhsNumber { get; set; }
    public string? NonPrimaryDiagnosisDate { get; set; }
    public string? NonPrimaryProgressionOriginalDiagnosis { get; set; }
}