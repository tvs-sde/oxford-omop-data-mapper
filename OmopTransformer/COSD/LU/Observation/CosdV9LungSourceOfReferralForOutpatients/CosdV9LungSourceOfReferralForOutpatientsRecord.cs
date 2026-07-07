using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Observation.CosdV9LungSourceOfReferralForOutpatients;

[DataOrigin("COSD")]
[Description("CosdV9LungSourceOfReferralForOutpatients")]
[SourceQuery("CosdV9LungSourceOfReferralForOutpatients.xml")]
internal class CosdV9LungSourceOfReferralForOutpatientsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralForOutpatients { get; set; }
}
