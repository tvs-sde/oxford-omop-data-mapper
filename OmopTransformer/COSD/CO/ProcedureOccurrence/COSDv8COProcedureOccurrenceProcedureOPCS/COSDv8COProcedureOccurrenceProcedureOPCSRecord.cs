using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CO.ProcedureOccurrence.COSDv8COProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 CO Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8COProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8COProcedureOccurrenceProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
