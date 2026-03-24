using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ProcedureOccurrence.COSDv9URProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 UR Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv9URProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv9URProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
