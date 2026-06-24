using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ConditionOccurrence.COSDv9CRConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 CR Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9CRConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9CRConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
