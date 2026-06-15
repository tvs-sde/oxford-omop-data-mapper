using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8URMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8URMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
