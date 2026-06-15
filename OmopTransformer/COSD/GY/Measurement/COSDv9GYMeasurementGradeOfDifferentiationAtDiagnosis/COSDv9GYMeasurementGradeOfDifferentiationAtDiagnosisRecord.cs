using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementGradeOfDifferentiationAtDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement Grade Of Differentiation At Diagnosis")]
[SourceQuery("COSDv9GYMeasurementGradeOfDifferentiationAtDiagnosis.xml")]
internal class COSDv9GYMeasurementGradeOfDifferentiationAtDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
