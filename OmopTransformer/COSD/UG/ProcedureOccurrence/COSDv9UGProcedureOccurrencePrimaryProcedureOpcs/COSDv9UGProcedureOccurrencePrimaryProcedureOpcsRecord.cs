using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ProcedureOccurrence.COSDv9UGProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 UG Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv9UGProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv9UGProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
