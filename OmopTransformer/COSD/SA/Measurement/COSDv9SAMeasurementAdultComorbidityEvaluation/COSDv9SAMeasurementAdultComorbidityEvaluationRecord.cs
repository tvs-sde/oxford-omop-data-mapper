using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9SAMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9SAMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation27Score { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
