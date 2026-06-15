using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8SAMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8SAMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
