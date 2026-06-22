using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement Grade of Differentiation (At Diagnosis)")]
[SourceQuery("CosdV9MeasurementGradeOfDifferentiation.xml")]
internal class CosdV9MeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}