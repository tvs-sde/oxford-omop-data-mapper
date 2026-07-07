using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ConditionOccurrence.COSDv8CRConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 CR Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8CRConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8CRConditionOccurrenceCancerProgressionICDRecord
{
    public string? NHSNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
