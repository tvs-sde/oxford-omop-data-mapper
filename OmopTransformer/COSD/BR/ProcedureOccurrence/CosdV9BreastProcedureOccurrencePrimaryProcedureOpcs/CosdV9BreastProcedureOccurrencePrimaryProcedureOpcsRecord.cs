using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV9BreastProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
