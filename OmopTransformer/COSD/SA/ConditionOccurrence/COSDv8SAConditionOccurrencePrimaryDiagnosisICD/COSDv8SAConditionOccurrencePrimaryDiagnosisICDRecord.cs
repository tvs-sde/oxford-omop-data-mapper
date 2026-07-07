using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ConditionOccurrence.COSDv8SAConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 SA Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8SAConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8SAConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosis { get; set; }
}
