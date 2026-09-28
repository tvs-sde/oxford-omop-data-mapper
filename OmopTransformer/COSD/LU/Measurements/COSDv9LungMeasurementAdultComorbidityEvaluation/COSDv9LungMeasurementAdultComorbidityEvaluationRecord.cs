using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Measurement.COSDv9LungMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9LungMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9LungMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
