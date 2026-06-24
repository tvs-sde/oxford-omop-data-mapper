using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ConditionOccurrence.COSDv9UGConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 UG Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9UGConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9UGConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
