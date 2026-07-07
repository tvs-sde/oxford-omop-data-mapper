using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV8ProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V8 Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV8ProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV8ProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}