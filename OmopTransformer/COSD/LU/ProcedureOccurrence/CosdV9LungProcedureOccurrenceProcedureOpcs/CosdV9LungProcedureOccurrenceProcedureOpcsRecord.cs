using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV9LungProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V9 Lung Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV9LungProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV9LungProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}