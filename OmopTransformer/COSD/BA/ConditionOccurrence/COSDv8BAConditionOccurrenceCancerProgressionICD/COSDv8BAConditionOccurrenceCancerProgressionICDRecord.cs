using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv8BAConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 BA Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8BAConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8BAConditionOccurrenceCancerProgressionICDRecord
{
    public string? NHSNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
