using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv9GYConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 GY Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9GYConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9GYConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
