using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV9LungConditionOccurrenceRecurrence;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Condition Occurrence Recurrence")]
[SourceQuery("CosdV9LungConditionOccurrenceRecurrence.xml")]
internal class CosdV9LungConditionOccurrenceRecurrenceRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? NonPrimaryRecurrenceOriginalDiagnosis { get; set; }
}