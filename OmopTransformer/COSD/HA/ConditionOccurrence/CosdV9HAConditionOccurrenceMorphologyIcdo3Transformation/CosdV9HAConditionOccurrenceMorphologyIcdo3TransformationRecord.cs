using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.CosdV9HAConditionOccurrenceMorphologyIcdo3Transformation;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Morphology ICD-O-3 Transformation")]
[SourceQuery("CosdV9HAConditionOccurrenceMorphologyIcdo3Transformation.xml")]
internal class CosdV9HAConditionOccurrenceMorphologyIcdo3TransformationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologyIcdo3Transformation { get; set; }
}
