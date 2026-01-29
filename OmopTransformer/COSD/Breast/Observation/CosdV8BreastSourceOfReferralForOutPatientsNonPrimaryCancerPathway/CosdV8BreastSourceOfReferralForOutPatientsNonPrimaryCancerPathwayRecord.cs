using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV8BreastSourceOfReferralForOutPatientsNonPrimaryCancerPathway;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Source Of Referral For Out Patients Non Primary Cancer Pathway")]
[SourceQuery("CosdV8BreastSourceOfReferralForOutPatientsNonPrimaryCancerPathway.xml")]
internal class CosdV8BreastSourceOfReferralForOutPatientsNonPrimaryCancerPathwayRecord
{
    public string? SourceOfReferralOutPatients { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
