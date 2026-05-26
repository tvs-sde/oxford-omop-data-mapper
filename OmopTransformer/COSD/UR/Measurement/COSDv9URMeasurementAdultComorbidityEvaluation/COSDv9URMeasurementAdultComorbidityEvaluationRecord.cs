using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9URMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9URMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
