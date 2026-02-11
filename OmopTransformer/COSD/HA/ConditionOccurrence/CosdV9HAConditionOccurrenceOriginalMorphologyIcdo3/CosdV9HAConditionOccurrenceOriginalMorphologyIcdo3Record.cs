using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.CosdV9HAConditionOccurrenceOriginalMorphologyIcdo3;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Original Morphology ICD-O-3")]
[SourceQuery("CosdV9HAConditionOccurrenceOriginalMorphologyIcdo3.xml")]
internal class CosdV9HAConditionOccurrenceOriginalMorphologyIcdo3Record
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalMorphologyIcdo3 { get; set; }
}
