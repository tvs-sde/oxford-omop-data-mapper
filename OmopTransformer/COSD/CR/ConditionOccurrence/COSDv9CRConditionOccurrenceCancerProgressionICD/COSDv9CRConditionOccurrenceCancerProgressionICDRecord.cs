using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ConditionOccurrence.COSDv9CRConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 CR Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9CRConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9CRConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
