using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungMenopausalStatus;

[DataOrigin("COSD")]
[Description("CosdV9LungMenopausalStatus")]
[SourceQuery("CosdV9LungMenopausalStatus.xml")]
internal class CosdV9LungMenopausalStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? MenopausalStatus { get; set; }
}
