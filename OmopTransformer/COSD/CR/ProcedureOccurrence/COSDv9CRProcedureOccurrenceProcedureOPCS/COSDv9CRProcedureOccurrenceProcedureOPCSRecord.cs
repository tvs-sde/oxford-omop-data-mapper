using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ProcedureOccurrence.COSDv9CRProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 CR Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv9CRProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv9CRProcedureOccurrenceProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
