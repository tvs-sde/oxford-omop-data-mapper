using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ConditionOccurrence.COSDv9UGConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 UG Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9UGConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9UGConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
