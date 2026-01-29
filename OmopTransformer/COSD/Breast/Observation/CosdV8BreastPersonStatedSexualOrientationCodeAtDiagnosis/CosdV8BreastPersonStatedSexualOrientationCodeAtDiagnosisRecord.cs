using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV8BreastPersonStatedSexualOrientationCodeAtDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Person Stated Sexual Orientation Code At Diagnosis")]
[SourceQuery("CosdV8BreastPersonStatedSexualOrientationCodeAtDiagnosis.xml")]
internal class CosdV8BreastPersonStatedSexualOrientationCodeAtDiagnosisRecord
{
    public string? PersonStatedSexualOrientationCodeAtDiagnosis { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
