using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceMorphologyIcdo3Transformation;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Morphology ICD-O-3 Transformation")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceMorphologyIcdo3Transformation.xml")]
internal class CosdV9HaematologicalConditionOccurrenceMorphologyIcdo3TransformationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologyIcdo3Transformation { get; set; }
}
