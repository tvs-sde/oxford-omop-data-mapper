using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ProcedureOccurrence.COSDv8SKProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 SK Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8SKProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8SKProcedureOccurrenceProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
