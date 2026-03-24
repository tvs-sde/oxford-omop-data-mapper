using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ProcedureOccurrence.COSDv9HAProcedureOccurrenceDiagnosticProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V9 HA Procedure Occurrence Diagnostic Procedure Opcs")]
[SourceQuery("COSDv9HAProcedureOccurrenceDiagnosticProcedureOpcs.xml")]
internal class COSDv9HAProcedureOccurrenceDiagnosticProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureOpcs { get; set; }
}
