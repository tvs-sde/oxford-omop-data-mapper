using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.ProcedureOccurrence.COSDv8GYProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 GY Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8GYProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8GYProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? PrimaryProcedureOPCS { get; set; }
    public string? ProcedureDate { get; set; }
}
