using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement Grade of Differentiation (At Diagnosis)")]
[SourceQuery("CosdV8LungMeasurementGradeOfDifferentiation.xml")]
internal class CosdV8LungMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}