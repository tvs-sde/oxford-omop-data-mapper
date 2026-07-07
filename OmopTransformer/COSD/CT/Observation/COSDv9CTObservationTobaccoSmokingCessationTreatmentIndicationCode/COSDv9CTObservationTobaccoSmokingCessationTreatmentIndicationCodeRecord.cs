using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationTobaccoSmokingCessationTreatmentIndicationCode;

[DataOrigin("COSD")]
[Description("COSD V9 CT Observation Tobacco Smoking Cessation Treatment Indication Code")]
[SourceQuery("COSDv9CTObservationTobaccoSmokingCessationTreatmentIndicationCode.xml")]
internal class COSDv9CTObservationTobaccoSmokingCessationTreatmentIndicationCodeRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TobaccoSmokingCessationTreatmentIndicationCode { get; set; }
}
