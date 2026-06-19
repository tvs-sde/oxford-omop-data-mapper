using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV9BreastProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV9BreastProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV9BreastProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}
