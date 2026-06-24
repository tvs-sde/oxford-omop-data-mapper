using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv9BAConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 BA Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9BAConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9BAConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
