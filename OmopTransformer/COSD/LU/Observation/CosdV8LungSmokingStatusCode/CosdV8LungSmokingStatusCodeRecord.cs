using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungSmokingStatusCode;

[DataOrigin("COSD")]
[Description("CosdV8LungSmokingStatusCode")]
[SourceQuery("CosdV8LungSmokingStatusCode.xml")]
internal class CosdV8LungSmokingStatusCodeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SmokingStatusCode { get; set; }
}
