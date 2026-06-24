using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ConditionOccurrence.COSDv9SAConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 SA Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9SAConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9SAConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
