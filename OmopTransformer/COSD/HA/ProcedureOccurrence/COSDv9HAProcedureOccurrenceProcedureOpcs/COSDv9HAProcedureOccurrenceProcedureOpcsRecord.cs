using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ProcedureOccurrence.COSDv9HAProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 HA Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv9HAProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv9HAProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
