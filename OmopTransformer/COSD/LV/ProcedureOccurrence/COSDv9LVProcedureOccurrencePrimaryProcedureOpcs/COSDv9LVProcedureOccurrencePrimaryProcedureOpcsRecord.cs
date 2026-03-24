using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ProcedureOccurrence.COSDv9LVProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 LV Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv9LVProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv9LVProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
