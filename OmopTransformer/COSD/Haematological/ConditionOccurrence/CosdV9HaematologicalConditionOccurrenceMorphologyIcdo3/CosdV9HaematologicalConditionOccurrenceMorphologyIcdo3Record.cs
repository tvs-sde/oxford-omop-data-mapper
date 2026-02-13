using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceMorphologyIcdo3;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Morphology ICD-O-3")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceMorphologyIcdo3.xml")]
internal class CosdV9HaematologicalConditionOccurrenceMorphologyIcdo3Record
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologyIcdo3 { get; set; }
}
