using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8HAMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8HAMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? DiagnosisGradeOfDifferentiation { get; set; }
}
