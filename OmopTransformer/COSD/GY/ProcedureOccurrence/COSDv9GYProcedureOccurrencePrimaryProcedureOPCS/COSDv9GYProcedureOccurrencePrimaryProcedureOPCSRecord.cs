using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ProcedureOccurrence.COSDv9GYProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 GY Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv9GYProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv9GYProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
