using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9SKMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9SKMeasurementAdultComorbidityEvaluationRecord
{
    public string? AdultComorbidityEvaluation27Score { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
