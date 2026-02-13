using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceOriginalMorphologyIcdo3;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Original Morphology ICD-O-3")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceOriginalMorphologyIcdo3.xml")]
internal class CosdV9HaematologicalConditionOccurrenceOriginalMorphologyIcdo3Record
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalMorphologyIcdo3 { get; set; }
}
