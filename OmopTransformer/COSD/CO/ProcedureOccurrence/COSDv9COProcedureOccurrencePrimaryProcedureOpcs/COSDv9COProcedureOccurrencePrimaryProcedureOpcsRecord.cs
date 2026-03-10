using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CO.ProcedureOccurrence.COSDv9COProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 CO Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("COSDv9COProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class COSDv9COProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
