using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV9MeasurementAdultComorbidityEvaluation")]
[SourceQuery("CosdV9MeasurementAdultComorbidityEvaluation.xml")]
internal class CosdV9MeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
