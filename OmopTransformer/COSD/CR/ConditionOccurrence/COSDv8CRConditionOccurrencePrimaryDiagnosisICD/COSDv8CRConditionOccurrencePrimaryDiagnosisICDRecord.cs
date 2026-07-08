using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ConditionOccurrence.COSDv8CRConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 CR Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8CRConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8CRConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NHSNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosisICD { get; set; }
}
