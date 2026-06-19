using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV9ProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V9 Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV9ProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV9ProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}   