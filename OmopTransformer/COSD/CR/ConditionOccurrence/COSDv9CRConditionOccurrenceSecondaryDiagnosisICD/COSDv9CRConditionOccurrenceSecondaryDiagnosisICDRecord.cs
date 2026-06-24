using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ConditionOccurrence.COSDv9CRConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 CR Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9CRConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9CRConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
