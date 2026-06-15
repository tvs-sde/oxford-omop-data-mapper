using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8LVMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8LVMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
