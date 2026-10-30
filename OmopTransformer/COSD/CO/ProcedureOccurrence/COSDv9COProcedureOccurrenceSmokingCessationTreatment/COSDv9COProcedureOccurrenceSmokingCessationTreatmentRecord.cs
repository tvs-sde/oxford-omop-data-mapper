using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CO.ProcedureOccurrence.COSDv9COProcedureOccurrenceSmokingCessationTreatment;

[DataOrigin("COSD")]
[Description("COSD V9 CO Procedure Occurrence Smoking Cessation Treatment")]
[SourceQuery("COSDv9COProcedureOccurrenceSmokingCessationTreatment.xml")]
internal class COSDv9COProcedureOccurrenceSmokingCessationTreatmentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? TobaccoSmokingCessation { get; set; }
}
