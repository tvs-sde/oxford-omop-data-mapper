using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8HNMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8HNMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
