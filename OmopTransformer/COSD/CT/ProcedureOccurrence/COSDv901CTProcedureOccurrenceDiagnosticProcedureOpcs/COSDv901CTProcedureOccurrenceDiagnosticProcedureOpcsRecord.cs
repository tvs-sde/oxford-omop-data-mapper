using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ProcedureOccurrence.COSDv901CTProcedureOccurrenceDiagnosticProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V901 CT Procedure Occurrence Diagnostic Procedure Opcs")]
[SourceQuery("COSDv901CTProcedureOccurrenceDiagnosticProcedureOpcs.xml")]
internal class COSDv901CTProcedureOccurrenceDiagnosticProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureOpcs { get; set; }
}
