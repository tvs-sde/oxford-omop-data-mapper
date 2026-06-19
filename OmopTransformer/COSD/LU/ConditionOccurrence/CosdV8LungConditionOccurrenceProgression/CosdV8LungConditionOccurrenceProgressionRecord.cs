using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV8LungConditionOccurrenceProgression;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Condition Occurrence Progression")]
[SourceQuery("CosdV8LungConditionOccurrenceProgression.xml")]
internal class CosdV8LungConditionOccurrenceProgressionRecord
{
    public string? NhsNumber { get; set; }
    public string? NonPrimaryDiagnosisDate { get; set; }
    public string? NonPrimaryProgressionOriginalDiagnosis { get; set; }
}