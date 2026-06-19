using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV8BreastProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
