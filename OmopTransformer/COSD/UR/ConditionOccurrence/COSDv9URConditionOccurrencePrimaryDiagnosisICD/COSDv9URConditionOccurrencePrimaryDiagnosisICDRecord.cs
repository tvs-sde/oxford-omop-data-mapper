using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ConditionOccurrence.COSDv9URConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 UR Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9URConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9URConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
