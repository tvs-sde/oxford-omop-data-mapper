using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ConditionOccurrence.COSDv9SKConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 SK Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9SKConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9SKConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
