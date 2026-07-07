using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ConditionOccurrence.COSDv9URConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 UR Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9URConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9URConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
