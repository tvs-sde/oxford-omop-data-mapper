using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Grade Of Differentiation")]
[SourceQuery("COSDv9LVMeasurementGradeOfDifferentiation.xml")]
internal class COSDv9LVMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
