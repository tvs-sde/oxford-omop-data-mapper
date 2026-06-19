using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV8BreastSmokingStatusCode;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Smoking Status Code")]
[SourceQuery("CosdV8BreastSmokingStatusCode.xml")]
internal class CosdV8BreastSmokingStatusCodeRecord
{
    public string? SmokingStatusCode { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
