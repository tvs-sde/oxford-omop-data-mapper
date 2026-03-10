using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv8HNProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V8 HN Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv8HNProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv8HNProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
