using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ProcedureOccurrence.COSDv9CRProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 CR Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv9CRProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv9CRProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
