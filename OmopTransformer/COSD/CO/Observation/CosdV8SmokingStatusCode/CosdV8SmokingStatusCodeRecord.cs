using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8SmokingStatusCode;

[DataOrigin("COSD")]
[Description("CosdV8SmokingStatusCode")]
[SourceQuery("CosdV8SmokingStatusCode.xml")]
internal class CosdV8SmokingStatusCodeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SmokingStatusCode { get; set; }
}
