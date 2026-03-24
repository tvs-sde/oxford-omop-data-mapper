using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ProcedureOccurrence.COSDv9UGProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 UG Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv9UGProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv9UGProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureOpcs { get; set; }
    public string? ProcedureDate { get; set; }
}
