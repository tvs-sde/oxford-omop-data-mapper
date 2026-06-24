using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ConditionOccurrence.COSDv8UGConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 UG Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8UGConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8UGConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosis { get; set; }
}
