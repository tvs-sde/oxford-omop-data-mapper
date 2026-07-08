using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ConditionOccurrence.COSDv9UGConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 UG Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9UGConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9UGConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
