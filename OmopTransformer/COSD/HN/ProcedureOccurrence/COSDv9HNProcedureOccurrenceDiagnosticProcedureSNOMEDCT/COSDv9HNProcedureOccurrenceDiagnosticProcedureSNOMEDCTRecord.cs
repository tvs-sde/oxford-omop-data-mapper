using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv9HNProcedureOccurrenceDiagnosticProcedureSNOMEDCT;

[DataOrigin("COSD")]
[Description("COSD V9 HN Procedure Occurrence Diagnostic Procedure SNOMEDCT")]
[SourceQuery("COSDv9HNProcedureOccurrenceDiagnosticProcedureSNOMEDCT.xml")]
internal class COSDv9HNProcedureOccurrenceDiagnosticProcedureSNOMEDCTRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
}
