using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ConditionOccurrence.COSDv8GYConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 GY Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8GYConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8GYConditionOccurrenceCancerProgressionICDRecord
{
    public string? NHSNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
