using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ProcedureOccurrence.COSDv9UGProcedureOccurrenceDiagnosticProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 UG Procedure Occurrence Diagnostic Procedure Opcs")]
[SourceQuery("COSDv9UGProcedureOccurrenceDiagnosticProcedureOpcs.xml")]
internal class COSDv9UGProcedureOccurrenceDiagnosticProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureOpcs { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
}
