using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ProcedureOccurrence.COSDv9BAProcedureOccurrenceProcedureOpcsProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V9 BA Procedure Occurrence Procedure Opcs Procedure Date")]
[SourceQuery("COSDv9BAProcedureOccurrenceProcedureOpcsProcedureDate.xml")]
internal class COSDv9BAProcedureOccurrenceProcedureOpcsProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcs { get; set; }
}
