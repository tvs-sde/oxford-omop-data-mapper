using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ProcedureOccurrence.COSDv8LVProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 LV Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8LVProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8LVProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
