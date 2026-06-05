using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement Grade Of Differentiation")]
[SourceQuery("COSDv9SKMeasurementGradeOfDifferentiation.xml")]
internal class COSDv9SKMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
