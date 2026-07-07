using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ConditionOccurrence.COSDv8SKConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 SK Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8SKConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8SKConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
