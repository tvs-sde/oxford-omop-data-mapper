using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceOriginalMorphologySnomed;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Original Morphology SNOMED")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceOriginalMorphologySnomed.xml")]
internal class CosdV9HaematologicalConditionOccurrenceOriginalMorphologySnomedRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalMorphologySnomed { get; set; }
}
