using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement Grade Of Differentiation")]
[SourceQuery("COSDv9CTMeasurementGradeOfDifferentiation.xml")]
internal class COSDv9CTMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
