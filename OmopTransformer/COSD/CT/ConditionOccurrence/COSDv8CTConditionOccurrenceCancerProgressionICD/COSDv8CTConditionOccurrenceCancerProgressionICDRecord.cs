using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ConditionOccurrence.COSDv8CTConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 CT Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8CTConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8CTConditionOccurrenceCancerProgressionICDRecord
{
    public string? NHSNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
