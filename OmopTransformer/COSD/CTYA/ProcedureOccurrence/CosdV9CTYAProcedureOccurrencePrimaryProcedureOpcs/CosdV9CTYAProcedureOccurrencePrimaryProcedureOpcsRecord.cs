using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CTYA.ProcedureOccurrence.CosdV9CTYAProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V9 CTYA Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV9CTYAProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV9CTYAProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}   
