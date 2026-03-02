using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ProcedureOccurrence.COSDv8URProcedureOccurrencePrimaryProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 UR Procedure Occurrence Primary Procedure OPCS")]
[SourceQuery("COSDv8URProcedureOccurrencePrimaryProcedureOPCS.xml")]
internal class COSDv8URProcedureOccurrencePrimaryProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOPCS { get; set; }
}
