using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungSurgicalAccessType;

[DataOrigin("COSD")]
[Description("CosdV8LungSurgicalAccessType")]
[SourceQuery("CosdV8LungSurgicalAccessType.xml")]
internal class CosdV8LungSurgicalAccessTypeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SurgicalAccessType { get; set; }
}
