using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV8BreastSourceOfReferralOutPatients;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Source Of Referral Out Patients")]
[SourceQuery("CosdV8BreastSourceOfReferralOutPatients.xml")]
internal class CosdV8BreastSourceOfReferralOutPatientsRecord
{
    public string? SourceOfReferralOutPatients { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
