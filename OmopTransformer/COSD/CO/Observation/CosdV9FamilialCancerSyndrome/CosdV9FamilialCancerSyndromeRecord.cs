using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9FamilialCancerSyndrome;

[DataOrigin("COSD")]
[Description("CosdV9FamilialCancerSyndrome")]
[SourceQuery("CosdV9FamilialCancerSyndrome.xml")]
internal class CosdV9FamilialCancerSyndromeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndrome { get; set; }
}
