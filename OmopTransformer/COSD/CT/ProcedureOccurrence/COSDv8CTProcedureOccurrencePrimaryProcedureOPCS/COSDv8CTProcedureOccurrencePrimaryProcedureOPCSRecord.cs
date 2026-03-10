using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ProcedureOccurrence.COSDv8CTProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 CT Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8CTProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8CTProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
