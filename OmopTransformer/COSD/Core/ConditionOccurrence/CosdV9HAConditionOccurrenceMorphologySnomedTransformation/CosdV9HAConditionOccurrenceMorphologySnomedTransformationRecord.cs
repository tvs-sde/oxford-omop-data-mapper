using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceMorphologySnomedTransformation;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Morphology SNOMED Transformation")]
[SourceQuery("COSDv9HAConditionOccurrenceMorphologySnomedTransformation.xml")]
internal class CosdV9HAConditionOccurrenceMorphologySnomedTransformationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologySnomedTransformation { get; set; }
}
