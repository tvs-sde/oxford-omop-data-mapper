using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv9HNProcedureOccurrenceDiagnosticProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 HN Procedure Occurrence Diagnostic Procedure OPCS")]
[SourceQuery("COSDv9HNProcedureOccurrenceDiagnosticProcedureOPCS.xml")]
internal class COSDv9HNProcedureOccurrenceDiagnosticProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureOpcs { get; set; }
}
