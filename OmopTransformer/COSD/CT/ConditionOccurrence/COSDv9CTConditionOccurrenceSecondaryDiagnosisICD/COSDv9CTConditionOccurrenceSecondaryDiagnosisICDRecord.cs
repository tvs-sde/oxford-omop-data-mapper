using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ConditionOccurrence.COSDv9CTConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 CT Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9CTConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9CTConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
