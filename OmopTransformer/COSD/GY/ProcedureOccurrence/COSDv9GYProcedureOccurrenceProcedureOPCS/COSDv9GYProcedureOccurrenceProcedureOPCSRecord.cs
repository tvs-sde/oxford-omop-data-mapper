using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ProcedureOccurrence.COSDv9GYProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 GY Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv9GYProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv9GYProcedureOccurrenceProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
