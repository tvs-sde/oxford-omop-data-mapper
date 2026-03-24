using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ProcedureOccurrence.COSDv9URProcedureOccurrenceDiagnosticProcedureSnomedCt;

[DataOrigin("COSD")]
[Description("COSD V9 UR Procedure Occurrence Diagnostic Procedure Snomed Ct")]
[SourceQuery("COSDv9URProcedureOccurrenceDiagnosticProcedureSnomedCt.xml")]
internal class COSDv9URProcedureOccurrenceDiagnosticProcedureSnomedCtRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
}
