using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ProcedureOccurrence.COSDv8LVProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 LV Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8LVProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8LVProcedureOccurrenceProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
