using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ConditionOccurrence.COSDv8SKConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 SK Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv8SKConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv8SKConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? SecondaryDiagnosisICD { get; set; }
}
