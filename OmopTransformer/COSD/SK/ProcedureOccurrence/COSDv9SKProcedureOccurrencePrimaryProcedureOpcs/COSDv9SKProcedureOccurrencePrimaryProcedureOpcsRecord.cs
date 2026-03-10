using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ProcedureOccurrence.COSDv9SKProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 SK Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv9SKProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv9SKProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
