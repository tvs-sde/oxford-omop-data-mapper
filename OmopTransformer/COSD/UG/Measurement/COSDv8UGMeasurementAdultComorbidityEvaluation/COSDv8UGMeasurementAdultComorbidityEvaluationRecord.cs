using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8UGMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8UGMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public string? MeasurementDate { get; set; }
}
