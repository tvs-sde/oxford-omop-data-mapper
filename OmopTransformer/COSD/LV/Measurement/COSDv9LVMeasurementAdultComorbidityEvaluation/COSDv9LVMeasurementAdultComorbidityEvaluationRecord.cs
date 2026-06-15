using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9LVMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9LVMeasurementAdultComorbidityEvaluationRecord
{
    public string? AdultComorbidityEvaluation { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? MeasurementDate { get; set; }
}
