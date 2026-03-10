using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv8HNProcedureOccurrenceDiagnosticProcedureSnomedCt;

[DataOrigin("COSD")]
[Description("COSD V8 HN Procedure Occurrence Diagnostic Procedure Snomed Ct")]
[SourceQuery("COSDv8HNProcedureOccurrenceDiagnosticProcedureSnomedCt.xml")]
internal class COSDv8HNProcedureOccurrenceDiagnosticProcedureSnomedCtRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
}
