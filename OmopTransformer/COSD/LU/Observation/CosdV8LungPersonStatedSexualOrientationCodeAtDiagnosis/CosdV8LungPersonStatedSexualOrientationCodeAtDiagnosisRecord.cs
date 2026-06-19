using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis;

[DataOrigin("COSD")]
[Description("CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis")]
[SourceQuery("CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis.xml")]
internal class CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? PersonStatedSexualOrientationCodeAtDiagnosis { get; set; }
}
