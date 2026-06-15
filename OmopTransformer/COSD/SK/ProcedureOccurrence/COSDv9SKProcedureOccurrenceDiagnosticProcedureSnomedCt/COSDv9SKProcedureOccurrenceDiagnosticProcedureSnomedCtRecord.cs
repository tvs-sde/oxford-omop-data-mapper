using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.ProcedureOccurrence.COSDv9SKProcedureOccurrenceDiagnosticProcedureSnomedCt;

[DataOrigin("COSD")]
[Description("COSD V9 SK Procedure Occurrence Diagnostic Procedure Snomed Ct")]
[SourceQuery("COSDv9SKProcedureOccurrenceDiagnosticProcedureSnomedCt.xml")]
internal class COSDv9SKProcedureOccurrenceDiagnosticProcedureSnomedCtRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
}
