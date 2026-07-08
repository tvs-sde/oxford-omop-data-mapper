using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ConditionOccurrence.COSDv9LVConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 LV Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9LVConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9LVConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
