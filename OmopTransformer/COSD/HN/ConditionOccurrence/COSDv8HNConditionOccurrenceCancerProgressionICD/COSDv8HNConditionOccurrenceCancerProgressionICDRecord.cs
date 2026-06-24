using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ConditionOccurrence.COSDv8HNConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 HN Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8HNConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8HNConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
