using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Grade Of Differentiation")]
[SourceQuery("COSDv9SAMeasurementGradeOfDifferentiation.xml")]
internal class COSDv9SAMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
