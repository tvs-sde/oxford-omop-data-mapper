using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ConditionOccurrence.COSDv9HNConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 HN Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9HNConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9HNConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
