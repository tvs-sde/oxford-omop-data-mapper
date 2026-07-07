using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ConditionOccurrence.COSDv8HNConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 HN Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8HNConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8HNConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosis { get; set; }
}
