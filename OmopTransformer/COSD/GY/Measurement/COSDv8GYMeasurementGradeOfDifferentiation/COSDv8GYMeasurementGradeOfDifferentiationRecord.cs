using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8GYMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8GYMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
