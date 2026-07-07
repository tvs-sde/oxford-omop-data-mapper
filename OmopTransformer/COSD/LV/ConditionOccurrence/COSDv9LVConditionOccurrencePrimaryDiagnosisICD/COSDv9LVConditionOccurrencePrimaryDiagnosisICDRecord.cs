using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ConditionOccurrence.COSDv9LVConditionOccurrencePrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 LV Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("COSDv9LVConditionOccurrencePrimaryDiagnosisICD.xml")]
internal class COSDv9LVConditionOccurrencePrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
