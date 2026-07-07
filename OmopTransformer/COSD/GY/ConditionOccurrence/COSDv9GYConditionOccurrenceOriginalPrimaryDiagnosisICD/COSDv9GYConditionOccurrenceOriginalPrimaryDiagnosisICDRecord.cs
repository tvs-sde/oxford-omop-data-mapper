using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv9GYConditionOccurrenceOriginalPrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 GY Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("COSDv9GYConditionOccurrenceOriginalPrimaryDiagnosisICD.xml")]
internal class COSDv9GYConditionOccurrenceOriginalPrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
