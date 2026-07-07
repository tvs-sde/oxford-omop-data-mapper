using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway;

[DataOrigin("COSD")]
[Description("CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway")]
[SourceQuery("CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway.xml")]
internal class CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathwayRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralForOutPatientsNonPrimaryCancerPathway { get; set; }
}
