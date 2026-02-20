using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV9BreastMeasurementAdultComorbidityEvaluation")]
[SourceQuery("CosdV9BreastMeasurementAdultComorbidityEvaluation.xml")]
internal class CosdV9BreastMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
