using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.ProcedureOccurrence.CosdV9LungProcedureOccurrenceTobaccoSmokingCessation;

[DataOrigin("COSD")]
[Description("COSD V9 LU Procedure Occurrence Tobacco Smoking Cessation")]
[SourceQuery("CosdV9LungProcedureOccurrenceTobaccoSmokingCessation.xml")]
internal class CosdV9LungProcedureOccurrenceTobaccoSmokingCessationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? TobaccoSmokingCessation { get; set; }
}
