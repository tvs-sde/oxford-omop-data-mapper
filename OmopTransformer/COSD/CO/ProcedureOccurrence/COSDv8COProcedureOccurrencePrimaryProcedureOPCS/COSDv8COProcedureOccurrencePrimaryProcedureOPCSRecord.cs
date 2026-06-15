using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CO.ProcedureOccurrence.COSDv8COProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 CO Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8COProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8COProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
