using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9GYMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9GYMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
