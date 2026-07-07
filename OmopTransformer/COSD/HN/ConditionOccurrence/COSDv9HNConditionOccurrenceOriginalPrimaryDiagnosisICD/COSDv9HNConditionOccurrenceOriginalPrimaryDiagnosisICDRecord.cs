using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ConditionOccurrence.COSDv9HNConditionOccurrenceOriginalPrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 HN Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("COSDv9HNConditionOccurrenceOriginalPrimaryDiagnosisICD.xml")]
internal class COSDv9HNConditionOccurrenceOriginalPrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
