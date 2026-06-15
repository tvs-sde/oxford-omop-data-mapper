using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CO.ProcedureOccurrence.COSDv9COProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 CO Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv9COProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv9COProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
