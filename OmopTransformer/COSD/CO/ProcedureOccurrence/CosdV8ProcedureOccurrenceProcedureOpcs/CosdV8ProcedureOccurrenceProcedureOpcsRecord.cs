using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV8ProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V8 Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV8ProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV8ProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}   