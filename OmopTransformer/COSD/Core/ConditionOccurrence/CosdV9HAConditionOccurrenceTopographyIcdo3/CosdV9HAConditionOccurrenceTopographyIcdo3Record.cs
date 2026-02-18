using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceTopographyIcdo3;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Topography ICD-O-3")]
[SourceQuery("COSDv9HAConditionOccurrenceTopographyIcdo3.xml")]
internal class CosdV9HAConditionOccurrenceTopographyIcdo3Record
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TopographyIcdo3 { get; set; }
}
