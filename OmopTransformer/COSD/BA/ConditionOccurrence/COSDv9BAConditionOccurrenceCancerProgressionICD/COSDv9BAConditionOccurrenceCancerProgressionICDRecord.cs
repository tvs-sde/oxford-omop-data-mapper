using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv9BAConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 BA Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9BAConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9BAConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
