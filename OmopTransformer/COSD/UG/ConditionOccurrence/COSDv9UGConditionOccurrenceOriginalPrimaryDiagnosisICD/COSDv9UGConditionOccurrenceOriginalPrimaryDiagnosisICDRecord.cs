using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ConditionOccurrence.COSDv9UGConditionOccurrenceOriginalPrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 UG Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("COSDv9UGConditionOccurrenceOriginalPrimaryDiagnosisICD.xml")]
internal class COSDv9UGConditionOccurrenceOriginalPrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
