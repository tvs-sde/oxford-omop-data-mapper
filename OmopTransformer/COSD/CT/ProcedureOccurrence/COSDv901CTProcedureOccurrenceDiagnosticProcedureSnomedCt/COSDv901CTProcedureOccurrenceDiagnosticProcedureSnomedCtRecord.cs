using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.ProcedureOccurrence.COSDv901CTProcedureOccurrenceDiagnosticProcedureSnomedCt;

[DataOrigin("COSD")]
[Description("COSD V901 CT Procedure Occurrence Diagnostic Procedure Snomed Ct")]
[SourceQuery("COSDv901CTProcedureOccurrenceDiagnosticProcedureSnomedCt.xml")]
internal class COSDv901CTProcedureOccurrenceDiagnosticProcedureSnomedCtRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
}
