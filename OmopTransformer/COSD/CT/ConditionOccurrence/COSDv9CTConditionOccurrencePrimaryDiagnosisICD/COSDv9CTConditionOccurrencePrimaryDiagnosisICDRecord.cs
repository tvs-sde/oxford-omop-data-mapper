using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ConditionOccurrence.COSDv9CTConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 CT Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9CTConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9CTConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
