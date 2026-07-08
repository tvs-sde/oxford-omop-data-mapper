using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ProcedureOccurrence.COSDv8CRProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 CR Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8CRProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8CRProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? PrimaryProcedureOPCS { get; set; }
    public string? ProcedureDate { get; set; }
}
