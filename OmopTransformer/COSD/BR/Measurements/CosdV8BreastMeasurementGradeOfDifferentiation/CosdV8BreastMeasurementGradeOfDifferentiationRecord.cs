using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement Grade of Differentiation (At Diagnosis)")]
[SourceQuery("CosdV8BreastMeasurementGradeOfDifferentiation.xml")]
internal class CosdV8BreastMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
