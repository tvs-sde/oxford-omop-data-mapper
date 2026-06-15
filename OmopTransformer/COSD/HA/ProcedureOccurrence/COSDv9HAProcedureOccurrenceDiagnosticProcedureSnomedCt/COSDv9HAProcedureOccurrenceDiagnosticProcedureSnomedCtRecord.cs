using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ProcedureOccurrence.COSDv9HAProcedureOccurrenceDiagnosticProcedureSnomedCt;

[DataOrigin("COSD")]
[Description("COSD V9 HA Procedure Occurrence Diagnostic Procedure Snomed Ct")]
[SourceQuery("COSDv9HAProcedureOccurrenceDiagnosticProcedureSnomedCt.xml")]
internal class COSDv9HAProcedureOccurrenceDiagnosticProcedureSnomedCtRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
}
