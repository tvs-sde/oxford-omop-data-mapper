using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CTYA.ProcedureOccurrence.CosdV9CTYAProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V9 CTYA Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV9CTYAProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV9CTYAProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}   
