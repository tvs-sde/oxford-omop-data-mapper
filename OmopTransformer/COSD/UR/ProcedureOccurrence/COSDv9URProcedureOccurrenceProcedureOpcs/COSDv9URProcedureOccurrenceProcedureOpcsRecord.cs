using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ProcedureOccurrence.COSDv9URProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 UR Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv9URProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv9URProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
