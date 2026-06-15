using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.ProcedureOccurrence.COSDv9LVProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 LV Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv9LVProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv9LVProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
