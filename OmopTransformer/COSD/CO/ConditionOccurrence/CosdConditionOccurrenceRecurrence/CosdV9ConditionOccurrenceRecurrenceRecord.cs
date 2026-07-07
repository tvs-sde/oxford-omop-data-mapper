using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrenceRecurrence;

[DataOrigin("COSD")]
[Description("COSD V9 Condition Occurrence Recurrence")]
[SourceQuery("CosdV9ConditionOccurrenceRecurrence.xml")]
internal class CosdV9ConditionOccurrenceRecurrenceRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? NonPrimaryRecurrenceOriginalDiagnosis { get; set; }
}