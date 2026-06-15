using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8GYMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8GYMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
