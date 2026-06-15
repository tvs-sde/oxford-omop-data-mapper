using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Grade Of Differentiation")]
[SourceQuery("COSDv9URMeasurementGradeOfDifferentiation.xml")]
internal class COSDv9URMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
