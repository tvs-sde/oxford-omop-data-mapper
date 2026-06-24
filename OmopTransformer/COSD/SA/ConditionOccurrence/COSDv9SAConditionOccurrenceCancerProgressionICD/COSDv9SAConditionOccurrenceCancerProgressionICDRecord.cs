using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ConditionOccurrence.COSDv9SAConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 SA Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9SAConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9SAConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
