using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway;

[DataOrigin("COSD")]
[Description("CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway")]
[SourceQuery("CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway.xml")]
internal class CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathwayRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralOutPatients { get; set; }
}
