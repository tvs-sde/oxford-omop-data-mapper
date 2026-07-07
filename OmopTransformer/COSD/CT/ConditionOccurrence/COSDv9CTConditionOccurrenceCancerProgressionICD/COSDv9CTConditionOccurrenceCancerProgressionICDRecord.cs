using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ConditionOccurrence.COSDv9CTConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 CT Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9CTConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9CTConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
