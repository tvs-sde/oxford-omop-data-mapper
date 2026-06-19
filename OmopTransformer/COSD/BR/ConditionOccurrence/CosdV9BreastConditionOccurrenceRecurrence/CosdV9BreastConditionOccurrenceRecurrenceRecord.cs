using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrenceRecurrence;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Condition Occurrence Recurrence")]
[SourceQuery("CosdV9BreastConditionOccurrenceRecurrence.xml")]
internal class CosdV9BreastConditionOccurrenceRecurrenceRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? NonPrimaryRecurrenceOriginalDiagnosis { get; set; }
}
