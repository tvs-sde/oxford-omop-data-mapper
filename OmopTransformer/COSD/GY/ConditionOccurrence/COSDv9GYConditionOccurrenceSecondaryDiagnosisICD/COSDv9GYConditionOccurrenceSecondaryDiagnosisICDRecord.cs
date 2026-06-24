using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv9GYConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 GY Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9GYConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9GYConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
