using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement Grade of Differentiation")]
[SourceQuery("CosdV9BreastMeasurementGradeOfDifferentiation.xml")]
internal class CosdV9BreastMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
