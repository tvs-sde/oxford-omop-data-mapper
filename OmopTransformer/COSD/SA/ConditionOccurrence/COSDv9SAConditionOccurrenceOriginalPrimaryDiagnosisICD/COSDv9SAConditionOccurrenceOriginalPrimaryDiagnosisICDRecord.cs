using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ConditionOccurrence.COSDv9SAConditionOccurrenceOriginalPrimaryDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V9 SA Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("COSDv9SAConditionOccurrenceOriginalPrimaryDiagnosisICD.xml")]
internal class COSDv9SAConditionOccurrenceOriginalPrimaryDiagnosisICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
