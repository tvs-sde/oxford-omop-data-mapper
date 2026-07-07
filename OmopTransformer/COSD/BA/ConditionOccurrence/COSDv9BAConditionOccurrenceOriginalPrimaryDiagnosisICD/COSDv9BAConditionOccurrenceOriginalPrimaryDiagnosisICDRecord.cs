using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv9BAConditionOccurrenceOriginalPrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 BA Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("COSDv9BAConditionOccurrenceOriginalPrimaryDiagnosisICD.xml")]
internal class COSDv9BAConditionOccurrenceOriginalPrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
