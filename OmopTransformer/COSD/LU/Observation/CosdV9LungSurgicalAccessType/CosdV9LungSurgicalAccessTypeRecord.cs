using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungSurgicalAccessType;

[DataOrigin("COSD")]
[Description("CosdV9LungSurgicalAccessType")]
[SourceQuery("CosdV9LungSurgicalAccessType.xml")]
internal class CosdV9LungSurgicalAccessTypeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SurgicalAccessType { get; set; }
}
