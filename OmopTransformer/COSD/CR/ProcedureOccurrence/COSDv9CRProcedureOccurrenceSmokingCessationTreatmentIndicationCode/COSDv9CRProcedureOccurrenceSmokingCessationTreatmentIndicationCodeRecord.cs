using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ProcedureOccurrence.COSDv9CRProcedureOccurrenceSmokingCessationTreatmentIndicationCode;

[DataOrigin("COSD")]
[Description("COSD V9 CR Procedure Occurrence Smoking Cessation Treatment Indication Code")]
[SourceQuery("COSDv9CRProcedureOccurrenceSmokingCessationTreatmentIndicationCode.xml")]
internal class COSDv9CRProcedureOccurrenceSmokingCessationTreatmentIndicationCodeRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TobaccoSmokingCessationTreatmentIndicationCode { get; set; }
}
