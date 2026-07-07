using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ConditionOccurrence.COSDv9SAConditionOccurrenceSecondaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 SA Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9SAConditionOccurrenceSecondaryDiagnosisICD.xml")]
internal class COSDv9SAConditionOccurrenceSecondaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
