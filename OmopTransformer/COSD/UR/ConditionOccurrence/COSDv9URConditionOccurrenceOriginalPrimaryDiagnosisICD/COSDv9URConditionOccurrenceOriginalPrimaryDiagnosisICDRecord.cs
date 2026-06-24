using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ConditionOccurrence.COSDv9URConditionOccurrenceOriginalPrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 UR Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("COSDv9URConditionOccurrenceOriginalPrimaryDiagnosisICD.xml")]
internal class COSDv9URConditionOccurrenceOriginalPrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
