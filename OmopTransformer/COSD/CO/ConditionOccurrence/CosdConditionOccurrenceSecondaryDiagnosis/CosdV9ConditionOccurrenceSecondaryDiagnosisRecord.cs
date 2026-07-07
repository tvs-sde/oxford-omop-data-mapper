using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrenceSecondaryDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 Condition Occurrence Recurrence")]
[SourceQuery("CosdV9ConditionOccurrenceSecondaryDiagnosis.xml")]
internal class CosdV9ConditionOccurrenceSecondaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosis { get; set; }
}