using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Grade Of Differentiation")]
[SourceQuery("COSDv9HAMeasurementGradeOfDifferentiation.xml")]
internal class COSDv9HAMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
