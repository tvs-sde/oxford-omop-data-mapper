using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.ProcedureOccurrence.COSDv8URProcedureOccurrenceProcedureOPCS;

[DataOrigin("COSD")]
[Description("COSD V8 UR Procedure Occurrence Procedure OPCS")]
[SourceQuery("COSDv8URProcedureOccurrenceProcedureOPCS.xml")]
internal class COSDv8URProcedureOccurrenceProcedureOPCSRecord
{
    public string? NHSNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOPCS { get; set; }
}
