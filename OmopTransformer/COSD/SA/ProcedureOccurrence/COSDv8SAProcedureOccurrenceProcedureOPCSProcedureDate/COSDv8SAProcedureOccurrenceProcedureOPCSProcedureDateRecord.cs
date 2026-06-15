using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ProcedureOccurrence.COSDv8SAProcedureOccurrenceProcedureOPCSProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V8 SA Procedure Occurrence Procedure OPCS Procedure Date")]
[SourceQuery("COSDv8SAProcedureOccurrenceProcedureOPCSProcedureDate.xml")]
internal class COSDv8SAProcedureOccurrenceProcedureOPCSProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
