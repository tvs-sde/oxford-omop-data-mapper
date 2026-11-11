using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ProcedureOccurrence.COSDv9CTProcedureOccurrenceTobaccoSmokingCessationTreatmentIndicationCode;

[DataOrigin("COSD")]
[Description("COSD V9 CT Procedure Occurrence Tobacco Smoking Cessation Treatment Indication Code")]
[SourceQuery("COSDv9CTProcedureOccurrenceTobaccoSmokingCessationTreatmentIndicationCode.xml")]
internal class COSDv9CTProcedureOccurrenceTobaccoSmokingCessationTreatmentIndicationCodeRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TobaccoSmokingCessationTreatmentIndicationCode { get; set; }
}
