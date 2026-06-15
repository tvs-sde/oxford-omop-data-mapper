using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9CTMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9CTMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation27Score { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
