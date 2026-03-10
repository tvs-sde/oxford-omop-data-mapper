using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv8HNProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V8 HN Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv8HNProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv8HNProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
