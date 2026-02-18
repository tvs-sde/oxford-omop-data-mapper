using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceOriginalMorphologySnomed;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Original Morphology SNOMED")]
[SourceQuery("COSDv9HAConditionOccurrenceOriginalMorphologySnomed.xml")]
internal class CosdV9HAConditionOccurrenceOriginalMorphologySnomedRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalMorphologySnomed { get; set; }
}
