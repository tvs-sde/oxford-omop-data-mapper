using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV8LungMeasurementAdultComorbidityEvaluation")]
[SourceQuery("CosdV8LungMeasurementAdultComorbidityEvaluation.xml")]
internal class CosdV8LungMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
