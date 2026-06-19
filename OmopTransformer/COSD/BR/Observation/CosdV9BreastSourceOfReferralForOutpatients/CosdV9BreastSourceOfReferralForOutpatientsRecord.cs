using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastSourceOfReferralForOutpatients;

[DataOrigin("COSD")]
[Description("CosdV9BreastSourceOfReferralForOutpatients")]
[SourceQuery("CosdV9BreastSourceOfReferralForOutpatients.xml")]
internal class CosdV9BreastSourceOfReferralForOutpatientsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralForOutpatients { get; set; }
}
