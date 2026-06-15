using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ProcedureOccurrence.COSDv8UGProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 UG Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8UGProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8UGProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
