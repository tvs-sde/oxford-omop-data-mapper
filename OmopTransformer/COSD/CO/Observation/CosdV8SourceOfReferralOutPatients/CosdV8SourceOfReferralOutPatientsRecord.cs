using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8SourceOfReferralOutPatients;

[DataOrigin("COSD")]
[Description("CosdV8SourceOfReferralOutPatients")]
[SourceQuery("CosdV8SourceOfReferralOutPatients.xml")]
internal class CosdV8SourceOfReferralOutPatientsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralOutPatients { get; set; }
}
