using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.ProcedureOccurrence.COSDv9SAProcedureOccurrenceProcedureOpcsProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V9 SA Procedure Occurrence Procedure Opcs Procedure Date")]
[SourceQuery("COSDv9SAProcedureOccurrenceProcedureOpcsProcedureDate.xml")]
internal class COSDv9SAProcedureOccurrenceProcedureOpcsProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
