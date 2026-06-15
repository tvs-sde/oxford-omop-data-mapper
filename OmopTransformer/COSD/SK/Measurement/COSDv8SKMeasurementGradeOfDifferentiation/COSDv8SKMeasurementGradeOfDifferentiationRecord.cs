using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8SKMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8SKMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
