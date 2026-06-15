using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementGradeOfDifferentiationAtDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement Grade Of Differentiation At Diagnosis")]
[SourceQuery("COSDv9HNMeasurementGradeOfDifferentiationAtDiagnosis.xml")]
internal class COSDv9HNMeasurementGradeOfDifferentiationAtDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
