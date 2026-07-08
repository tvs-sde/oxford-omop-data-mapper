using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.ProcedureOccurrence.COSDv8HNProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 HN Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8HNProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8HNProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? PrimaryProcedureOPCS { get; set; }
    public string? ProcedureDate { get; set; }
}
