using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceMorphologyIcdo3;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Morphology ICD-O-3")]
[SourceQuery("COSDv9HAConditionOccurrenceMorphologyIcdo3.xml")]
internal class CosdV9HAConditionOccurrenceMorphologyIcdo3Record
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologyIcdo3 { get; set; }
}
