using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungSourceOfReferralOutPatients;

[DataOrigin("COSD")]
[Description("CosdV8LungSourceOfReferralOutPatients")]
[SourceQuery("CosdV8LungSourceOfReferralOutPatients.xml")]
internal class CosdV8LungSourceOfReferralOutPatientsRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SourceOfReferralOutPatients { get; set; }
}
