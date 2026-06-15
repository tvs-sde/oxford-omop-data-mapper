using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9CRMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9CRMeasurementAdultComorbidityEvaluationRecord
{
    public string? AdultComorbidityEvaluation { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
