using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV9ProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V9 Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV9ProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV9ProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}   