using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ConditionOccurrence.COSDv8LVConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 LV Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8LVConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8LVConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
