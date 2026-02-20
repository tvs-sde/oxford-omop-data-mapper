using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV8MeasurementAdultComorbidityEvaluation")]
[SourceQuery("CosdV8MeasurementAdultComorbidityEvaluation.xml")]
internal class CosdV8MeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
