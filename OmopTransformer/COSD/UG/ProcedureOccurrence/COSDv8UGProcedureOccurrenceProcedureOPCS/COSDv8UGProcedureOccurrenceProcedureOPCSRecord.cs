using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ProcedureOccurrence.COSDv8UGProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 UG Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8UGProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8UGProcedureOccurrenceProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
