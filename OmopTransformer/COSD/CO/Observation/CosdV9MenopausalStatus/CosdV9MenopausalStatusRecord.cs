using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9MenopausalStatus;

[DataOrigin("COSD")]
[Description("CosdV9MenopausalStatus")]
[SourceQuery("CosdV9MenopausalStatus.xml")]
internal class CosdV9MenopausalStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? MenopausalStatus { get; set; }
}
