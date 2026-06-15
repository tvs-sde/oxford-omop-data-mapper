using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ProcedureOccurrence.COSDv901CTProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V901 CT Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv901CTProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv901CTProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
