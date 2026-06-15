using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V8 HN Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8HNMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8HNMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
