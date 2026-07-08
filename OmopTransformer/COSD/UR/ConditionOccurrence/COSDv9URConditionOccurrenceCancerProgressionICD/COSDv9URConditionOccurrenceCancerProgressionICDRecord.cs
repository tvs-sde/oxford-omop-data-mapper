using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ConditionOccurrence.COSDv9URConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V9 UR Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv9URConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv9URConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
