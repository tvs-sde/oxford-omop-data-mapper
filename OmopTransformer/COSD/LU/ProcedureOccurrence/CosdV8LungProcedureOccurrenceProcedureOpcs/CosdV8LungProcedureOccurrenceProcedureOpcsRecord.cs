using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V8 Lung Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV8LungProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV8LungProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}