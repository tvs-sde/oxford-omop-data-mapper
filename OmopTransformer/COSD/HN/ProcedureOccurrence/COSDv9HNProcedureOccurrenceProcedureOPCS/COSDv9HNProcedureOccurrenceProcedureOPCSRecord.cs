using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv9HNProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 HN Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv9HNProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv9HNProcedureOccurrenceProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
