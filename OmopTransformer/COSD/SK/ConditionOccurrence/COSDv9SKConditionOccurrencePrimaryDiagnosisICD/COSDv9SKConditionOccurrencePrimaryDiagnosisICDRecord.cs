using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ConditionOccurrence.COSDv9SKConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 SK Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9SKConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9SKConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
