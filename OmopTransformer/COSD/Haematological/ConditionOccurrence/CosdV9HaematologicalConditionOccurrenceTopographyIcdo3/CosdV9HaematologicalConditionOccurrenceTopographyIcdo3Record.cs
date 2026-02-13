using OmopTransformer.Annotations;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceTopographyIcdo3;

/// <summary>
/// Represents haematological cancer topography data from COSD v9 using ICD-O-3 codes.
/// </summary>
[DataOrigin("COSD")]
[Description("Haematological cancer topography from COSD v9")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceTopographyIcdo3.xml")]
internal class CosdV9HaematologicalConditionOccurrenceTopographyIcdo3Record
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TopographyIcdo3 { get; set; }
}
