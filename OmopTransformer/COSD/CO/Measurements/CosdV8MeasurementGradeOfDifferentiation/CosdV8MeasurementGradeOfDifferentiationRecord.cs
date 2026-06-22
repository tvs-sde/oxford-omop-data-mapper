using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement Grade of Differentiation (At Diagnosis)")]
[SourceQuery("CosdV8MeasurementGradeOfDifferentiation.xml")]
internal class CosdV8MeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}