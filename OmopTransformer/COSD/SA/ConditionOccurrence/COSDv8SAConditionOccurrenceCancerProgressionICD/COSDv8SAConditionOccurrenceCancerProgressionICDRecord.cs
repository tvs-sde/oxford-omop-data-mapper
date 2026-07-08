using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ConditionOccurrence.COSDv8SAConditionOccurrenceCancerProgressionICD;

[DataOrigin("COSD")]
[Description("COSD V8 SA Condition Occurrence Cancer Progression ICD")]
[SourceQuery("COSDv8SAConditionOccurrenceCancerProgressionICD.xml")]
internal class COSDv8SAConditionOccurrenceCancerProgressionICDRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? CancerProgressionICD { get; set; }
}
