using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv9HNProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 HN Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv9HNProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv9HNProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
