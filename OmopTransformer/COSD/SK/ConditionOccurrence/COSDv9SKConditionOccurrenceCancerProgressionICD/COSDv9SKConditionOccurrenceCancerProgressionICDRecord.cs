using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ConditionOccurrence.COSDv9SKConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 SK Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9SKConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9SKConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
