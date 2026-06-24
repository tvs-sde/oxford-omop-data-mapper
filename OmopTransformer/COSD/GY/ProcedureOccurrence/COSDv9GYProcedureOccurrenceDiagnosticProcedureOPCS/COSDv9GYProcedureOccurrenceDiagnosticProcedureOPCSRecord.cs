using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ProcedureOccurrence.COSDv9GYProcedureOccurrenceDiagnosticProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V9 GY Procedure Occurrence Diagnostic Procedure OPCS")]
[SourceQuery("COSDv9GYProcedureOccurrenceDiagnosticProcedureOPCS.xml")]
internal class COSDv9GYProcedureOccurrenceDiagnosticProcedureOPCSRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureOpcs { get; set; }
}
