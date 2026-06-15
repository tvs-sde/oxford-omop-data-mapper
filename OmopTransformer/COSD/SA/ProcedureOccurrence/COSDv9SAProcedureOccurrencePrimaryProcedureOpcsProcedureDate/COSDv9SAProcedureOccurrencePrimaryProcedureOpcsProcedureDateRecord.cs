using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ProcedureOccurrence.COSDv9SAProcedureOccurrencePrimaryProcedureOpcsProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V9 SA Procedure Occurrence Primary Procedure Opcs Procedure Date")]
[SourceQuery("COSDv9SAProcedureOccurrencePrimaryProcedureOpcsProcedureDate.xml")]
internal class COSDv9SAProcedureOccurrencePrimaryProcedureOpcsProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
