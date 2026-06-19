using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungSourceOfReferralForNonPrimaryCancerPathway;

[DataOrigin("COSD")]
[Description("CosdV9LungSourceOfReferralForNonPrimaryCancerPathway")]
[SourceQuery("CosdV9LungSourceOfReferralForNonPrimaryCancerPathway.xml")]
internal class CosdV9LungSourceOfReferralForNonPrimaryCancerPathwayRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralForNonPrimaryCancerPathway { get; set; }
}
