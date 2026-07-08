using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ConditionOccurrence.COSDv8CTConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 CT Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8CTConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8CTConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NHSNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosisICD { get; set; }
}
