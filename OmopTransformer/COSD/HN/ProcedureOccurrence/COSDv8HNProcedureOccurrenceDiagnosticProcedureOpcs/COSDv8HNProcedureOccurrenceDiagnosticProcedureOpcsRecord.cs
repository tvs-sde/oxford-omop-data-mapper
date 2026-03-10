using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv8HNProcedureOccurrenceDiagnosticProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V8 HN Procedure Occurrence Diagnostic Procedure Opcs")]
[SourceQuery("COSDv8HNProcedureOccurrenceDiagnosticProcedureOpcs.xml")]
internal class COSDv8HNProcedureOccurrenceDiagnosticProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureOpcs { get; set; }
}
