using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastFamilialCancerSyndrome;

[DataOrigin("COSD")]
[Description("CosdV9BreastFamilialCancerSyndrome")]
[SourceQuery("CosdV9BreastFamilialCancerSyndrome.xml")]
internal class CosdV9BreastFamilialCancerSyndromeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndrome { get; set; }
}
