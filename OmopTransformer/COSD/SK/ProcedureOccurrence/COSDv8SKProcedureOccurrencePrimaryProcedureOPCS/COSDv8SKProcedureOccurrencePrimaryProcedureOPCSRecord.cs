using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ProcedureOccurrence.COSDv8SKProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 SK Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8SKProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8SKProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
