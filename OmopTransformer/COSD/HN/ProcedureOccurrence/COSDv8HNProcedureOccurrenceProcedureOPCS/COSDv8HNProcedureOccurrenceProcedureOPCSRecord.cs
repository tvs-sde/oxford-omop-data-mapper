using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv8HNProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 HN Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8HNProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8HNProcedureOccurrenceProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? ProcedureOPCS { get; set; }
    public string? ProcedureDate { get; set; }
}
