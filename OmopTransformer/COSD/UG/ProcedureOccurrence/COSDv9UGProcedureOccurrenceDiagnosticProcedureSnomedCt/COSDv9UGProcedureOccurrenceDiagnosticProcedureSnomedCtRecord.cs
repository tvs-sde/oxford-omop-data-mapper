using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.ProcedureOccurrence.COSDv9UGProcedureOccurrenceDiagnosticProcedureSnomedCt;

[DataOrigin("COSD")]
[Description("COSD V9 UG Procedure Occurrence Diagnostic Procedure Snomed Ct")]
[SourceQuery("COSDv9UGProcedureOccurrenceDiagnosticProcedureSnomedCt.xml")]
internal class COSDv9UGProcedureOccurrenceDiagnosticProcedureSnomedCtRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
}
