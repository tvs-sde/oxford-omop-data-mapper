using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ConditionOccurrence.COSDv9HNConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 HN Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9HNConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9HNConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
