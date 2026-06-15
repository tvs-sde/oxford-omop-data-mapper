using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Grade Of Differentiation")]
[SourceQuery("COSDv9CRMeasurementGradeOfDifferentiation.xml")]
internal class COSDv9CRMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
