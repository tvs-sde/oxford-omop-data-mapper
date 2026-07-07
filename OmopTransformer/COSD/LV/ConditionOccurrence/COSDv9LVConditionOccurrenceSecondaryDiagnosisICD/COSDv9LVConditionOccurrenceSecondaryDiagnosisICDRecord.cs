using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ConditionOccurrence.COSDv9LVConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 LV Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9LVConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9LVConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
