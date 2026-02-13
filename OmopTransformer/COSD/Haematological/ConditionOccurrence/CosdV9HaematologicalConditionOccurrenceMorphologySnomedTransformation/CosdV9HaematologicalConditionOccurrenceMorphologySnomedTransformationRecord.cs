using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceMorphologySnomedTransformation;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Morphology SNOMED Transformation")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceMorphologySnomedTransformation.xml")]
internal class CosdV9HaematologicalConditionOccurrenceMorphologySnomedTransformationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologySnomedTransformation { get; set; }
}
