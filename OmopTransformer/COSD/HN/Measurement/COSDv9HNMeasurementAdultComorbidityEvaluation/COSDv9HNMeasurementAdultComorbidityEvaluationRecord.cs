using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9HNMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9HNMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public string? MeasurementDate { get; set; }
}
