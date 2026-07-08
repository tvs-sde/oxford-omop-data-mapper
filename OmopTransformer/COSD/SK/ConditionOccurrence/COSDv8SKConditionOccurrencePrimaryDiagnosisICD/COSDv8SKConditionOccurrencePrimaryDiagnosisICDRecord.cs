using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ConditionOccurrence.COSDv8SKConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 SK Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8SKConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8SKConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosis { get; set; }
}
