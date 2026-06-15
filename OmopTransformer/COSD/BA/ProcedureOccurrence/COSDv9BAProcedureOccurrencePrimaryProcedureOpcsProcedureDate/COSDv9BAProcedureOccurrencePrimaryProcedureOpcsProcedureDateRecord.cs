using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ProcedureOccurrence.COSDv9BAProcedureOccurrencePrimaryProcedureOpcsProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V9 BA Procedure Occurrence Primary Procedure Opcs Procedure Date")]
[SourceQuery("COSDv9BAProcedureOccurrencePrimaryProcedureOpcsProcedureDate.xml")]
internal class COSDv9BAProcedureOccurrencePrimaryProcedureOpcsProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
