using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementGradeOfDifferentiationAtDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement Grade Of Differentiation At Diagnosis")]
[SourceQuery("COSDv9UGMeasurementGradeOfDifferentiationAtDiagnosis.xml")]
internal class COSDv9UGMeasurementGradeOfDifferentiationAtDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
