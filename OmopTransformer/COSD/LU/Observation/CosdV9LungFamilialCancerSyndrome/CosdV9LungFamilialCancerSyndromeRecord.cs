using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungFamilialCancerSyndrome;

[DataOrigin("COSD")]
[Description("CosdV9LungFamilialCancerSyndrome")]
[SourceQuery("CosdV9LungFamilialCancerSyndrome.xml")]
internal class CosdV9LungFamilialCancerSyndromeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndrome { get; set; }
}
