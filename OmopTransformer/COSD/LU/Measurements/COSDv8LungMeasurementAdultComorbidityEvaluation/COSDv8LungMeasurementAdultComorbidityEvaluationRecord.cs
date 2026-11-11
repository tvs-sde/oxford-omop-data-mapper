using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Measurement.COSDv8LungMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8LungMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8LungMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
