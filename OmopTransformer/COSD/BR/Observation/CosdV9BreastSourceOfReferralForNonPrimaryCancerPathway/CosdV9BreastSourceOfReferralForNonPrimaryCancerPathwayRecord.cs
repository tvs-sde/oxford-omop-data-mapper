using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway;

[DataOrigin("COSD")]
[Description("CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway")]
[SourceQuery("CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway.xml")]
internal class CosdV9BreastSourceOfReferralForNonPrimaryCancerPathwayRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralForNonPrimaryCancerPathway { get; set; }
}
