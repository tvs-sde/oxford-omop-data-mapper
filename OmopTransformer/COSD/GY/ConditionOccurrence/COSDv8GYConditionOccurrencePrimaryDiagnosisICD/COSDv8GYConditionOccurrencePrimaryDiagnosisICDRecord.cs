using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv8GYConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 GY Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8GYConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8GYConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NHSNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosisICD { get; set; }
}
