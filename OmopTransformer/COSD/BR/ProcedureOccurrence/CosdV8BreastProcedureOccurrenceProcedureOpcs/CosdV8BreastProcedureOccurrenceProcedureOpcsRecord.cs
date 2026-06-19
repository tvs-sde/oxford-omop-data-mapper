using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV8BreastProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV8BreastProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV8BreastProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}
