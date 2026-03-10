using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ProcedureOccurrence.COSDv9SKProcedureOccurrenceDiagnosticProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 SK Procedure Occurrence Diagnostic Procedure Opcs")]
[SourceQuery("COSDv9SKProcedureOccurrenceDiagnosticProcedureOpcs.xml")]
internal class COSDv9SKProcedureOccurrenceDiagnosticProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureOpcs { get; set; }
}
