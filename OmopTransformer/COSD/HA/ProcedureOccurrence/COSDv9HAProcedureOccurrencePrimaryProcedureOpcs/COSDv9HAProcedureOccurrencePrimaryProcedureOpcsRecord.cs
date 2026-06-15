using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ProcedureOccurrence.COSDv9HAProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 HA Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv9HAProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv9HAProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
