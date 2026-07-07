using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ConditionOccurrence.COSDv8UGConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 UG Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8UGConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8UGConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
