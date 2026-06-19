using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastMenopausalStatus;

[DataOrigin("COSD")]
[Description("CosdV9BreastMenopausalStatus")]
[SourceQuery("CosdV9BreastMenopausalStatus.xml")]
internal class CosdV9BreastMenopausalStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? MenopausalStatus { get; set; }
}
