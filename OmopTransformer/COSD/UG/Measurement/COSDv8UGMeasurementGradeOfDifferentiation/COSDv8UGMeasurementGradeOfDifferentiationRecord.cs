using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8UGMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8UGMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
