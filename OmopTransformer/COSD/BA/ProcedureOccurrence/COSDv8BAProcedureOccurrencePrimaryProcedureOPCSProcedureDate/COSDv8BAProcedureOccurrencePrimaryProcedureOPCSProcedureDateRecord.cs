using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ProcedureOccurrence.COSDv8BAProcedureOccurrencePrimaryProcedureOPCSProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V8 BA Procedure Occurrence Primary Procedure OPCS Procedure Date")]
[SourceQuery("COSDv8BAProcedureOccurrencePrimaryProcedureOPCSProcedureDate.xml")]
internal class COSDv8BAProcedureOccurrencePrimaryProcedureOPCSProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
