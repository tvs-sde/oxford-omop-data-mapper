using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ProcedureOccurrence.COSDv9GYProcedureOccurrenceDiagnosticProcedureSNOMEDCT;

[DataOrigin("COSD")]
[Description("COSD V9 GY Procedure Occurrence Diagnostic Procedure SNOMEDCT")]
[SourceQuery("COSDv9GYProcedureOccurrenceDiagnosticProcedureSNOMEDCT.xml")]
internal class COSDv9GYProcedureOccurrenceDiagnosticProcedureSNOMEDCTRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosticProcedureDate { get; set; }
    public string? DiagnosticProcedureSnomedCt { get; set; }
}
