using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementAdultComorbidityEvaluation27Score;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement Adult Comorbidity Evaluation 27 Score")]
[SourceQuery("COSDv9UGMeasurementAdultComorbidityEvaluation27Score.xml")]
internal class COSDv9UGMeasurementAdultComorbidityEvaluation27ScoreRecord
{
    public string? AdultComorbidityEvaluation27Score { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
