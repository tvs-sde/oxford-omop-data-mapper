using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ProcedureOccurrence.COSDv901CTProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V901 CT Procedure Occurrence Procedure Opcs")]
[SourceQuery("COSDv901CTProcedureOccurrenceProcedureOpcs.xml")]
internal class COSDv901CTProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
