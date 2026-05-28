using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8SKMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8SKMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
