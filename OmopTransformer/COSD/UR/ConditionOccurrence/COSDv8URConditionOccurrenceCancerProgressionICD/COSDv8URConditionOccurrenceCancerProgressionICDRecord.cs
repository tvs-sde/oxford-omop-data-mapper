using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ConditionOccurrence.COSDv8URConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 UR Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8URConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8URConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
