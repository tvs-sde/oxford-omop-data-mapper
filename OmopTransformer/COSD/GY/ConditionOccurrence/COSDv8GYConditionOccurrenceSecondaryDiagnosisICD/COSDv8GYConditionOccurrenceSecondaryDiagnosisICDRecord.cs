using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv8GYConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 GY Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv8GYConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv8GYConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NHSNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? SecondaryDiagnosisICD { get; set; }
}
