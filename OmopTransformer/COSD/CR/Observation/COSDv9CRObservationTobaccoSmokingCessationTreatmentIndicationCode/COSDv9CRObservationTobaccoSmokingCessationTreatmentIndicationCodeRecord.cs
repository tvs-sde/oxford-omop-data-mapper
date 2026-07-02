using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationTobaccoSmokingCessationTreatmentIndicationCode;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Tobacco Smoking Cessation Treatment Indication Code")]
[SourceQuery("COSDv9CRObservationTobaccoSmokingCessationTreatmentIndicationCode.xml")]
internal class COSDv9CRObservationTobaccoSmokingCessationTreatmentIndicationCodeRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TobaccoSmokingCessationTreatmentIndicationCode { get; set; }
}
