using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementGradeOfDifferentiationAtDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement Grade Of Differentiation At Diagnosis")]
[SourceQuery("COSDv9BAMeasurementGradeOfDifferentiationAtDiagnosis.xml")]
internal class COSDv9BAMeasurementGradeOfDifferentiationAtDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
