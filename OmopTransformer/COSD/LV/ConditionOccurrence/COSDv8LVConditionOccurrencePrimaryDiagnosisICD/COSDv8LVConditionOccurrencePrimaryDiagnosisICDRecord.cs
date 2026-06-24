using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ConditionOccurrence.COSDv8LVConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 LV Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8LVConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8LVConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosis { get; set; }
}
