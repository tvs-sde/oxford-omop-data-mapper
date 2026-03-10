using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ProcedureOccurrence.COSDv9BAProcedureOccurrenceBiopsyTypeProcedureDate;

[DataOrigin("COSD")]
[Description("COSD V9 BA Procedure Occurrence Biopsy Type Procedure Date")]
[SourceQuery("COSDv9BAProcedureOccurrenceBiopsyTypeProcedureDate.xml")]
internal class COSDv9BAProcedureOccurrenceBiopsyTypeProcedureDateRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? BiopsyType { get; set; }
}
