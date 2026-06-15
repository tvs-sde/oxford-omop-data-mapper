using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ProcedureOccurrence.COSDv9SKProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 SK Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv9SKProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv9SKProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
