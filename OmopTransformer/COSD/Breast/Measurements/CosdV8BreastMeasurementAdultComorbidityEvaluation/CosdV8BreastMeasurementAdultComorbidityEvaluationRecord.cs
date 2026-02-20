using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV8BreastMeasurementAdultComorbidityEvaluation")]
[SourceQuery("CosdV8BreastMeasurementAdultComorbidityEvaluation.xml")]
internal class CosdV8BreastMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
