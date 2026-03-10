using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ProcedureOccurrence.COSDv8SAProcedureOccurrencePrimaryProcedureOPCSProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V8 SA Procedure Occurrence Primary Procedure OPCS Procedure Date")]
[SourceQuery("COSDv8SAProcedureOccurrencePrimaryProcedureOPCSProcedureDate.xml")]
internal class COSDv8SAProcedureOccurrencePrimaryProcedureOPCSProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
