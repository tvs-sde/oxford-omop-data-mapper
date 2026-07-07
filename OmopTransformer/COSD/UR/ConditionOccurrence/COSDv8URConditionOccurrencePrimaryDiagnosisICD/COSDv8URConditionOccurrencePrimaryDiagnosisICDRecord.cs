using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ConditionOccurrence.COSDv8URConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 UR Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8URConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8URConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosis { get; set; }
}
