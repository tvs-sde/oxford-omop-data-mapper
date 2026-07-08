using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ProcedureOccurrence.COSDv8GYProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 GY Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8GYProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8GYProcedureOccurrenceProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? ProcedureOPCS { get; set; }
    public string? ProcedureDate { get; set; }
}
