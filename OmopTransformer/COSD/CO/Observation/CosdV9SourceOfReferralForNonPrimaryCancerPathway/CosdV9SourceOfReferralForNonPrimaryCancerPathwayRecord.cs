using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9SourceOfReferralForNonPrimaryCancerPathway;

[DataOrigin("COSD")]
[Description("CosdV9SourceOfReferralForNonPrimaryCancerPathway")]
[SourceQuery("CosdV9SourceOfReferralForNonPrimaryCancerPathway.xml")]
internal class CosdV9SourceOfReferralForNonPrimaryCancerPathwayRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralForNonPrimaryCancerPathway { get; set; }
}
