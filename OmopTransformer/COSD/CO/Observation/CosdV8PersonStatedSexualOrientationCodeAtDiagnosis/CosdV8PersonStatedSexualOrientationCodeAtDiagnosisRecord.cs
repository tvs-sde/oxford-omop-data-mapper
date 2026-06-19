using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8PersonStatedSexualOrientationCodeAtDiagnosis;

[DataOrigin("COSD")]
[Description("CosdV8PersonStatedSexualOrientationCodeAtDiagnosis")]
[SourceQuery("CosdV8PersonStatedSexualOrientationCodeAtDiagnosis.xml")]
internal class CosdV8PersonStatedSexualOrientationCodeAtDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? PersonStatedSexualOrientationCodeAtDiagnosis { get; set; }
}
