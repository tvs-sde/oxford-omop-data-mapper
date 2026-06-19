using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement Grade of Differentiation (At Diagnosis)")]
[SourceQuery("CosdV9LungMeasurementGradeOfDifferentiation.xml")]
internal class CosdV9LungMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
