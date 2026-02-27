using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV9LungMeasurementAdultComorbidityEvaluation")]
[SourceQuery("CosdV9LungMeasurementAdultComorbidityEvaluation.xml")]
internal class CosdV9LungMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
