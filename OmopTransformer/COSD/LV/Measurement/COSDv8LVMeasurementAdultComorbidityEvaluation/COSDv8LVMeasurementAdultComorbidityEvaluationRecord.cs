using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8LVMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8LVMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
