using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.ProcedureOccurrence.COSDv8CRProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 CR Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8CRProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8CRProcedureOccurrenceProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? ProcedureOPCS { get; set; }
    public string? ProcedureDate { get; set; }
}
