using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv8BAConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 BA Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv8BAConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv8BAConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NHSNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? PrimaryDiagnosisICD { get; set; }
}
