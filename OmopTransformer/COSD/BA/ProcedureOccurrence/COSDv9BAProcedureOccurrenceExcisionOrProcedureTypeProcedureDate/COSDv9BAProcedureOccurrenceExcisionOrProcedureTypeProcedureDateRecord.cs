using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ProcedureOccurrence.COSDv9BAProcedureOccurrenceExcisionOrProcedureTypeProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V9 BA Procedure Occurrence Excision Or Procedure Type Procedure Date")]
[SourceQuery("COSDv9BAProcedureOccurrenceExcisionOrProcedureTypeProcedureDate.xml")]
internal class COSDv9BAProcedureOccurrenceExcisionOrProcedureTypeProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ExcisionOrProcedureType { get; set; }
}
