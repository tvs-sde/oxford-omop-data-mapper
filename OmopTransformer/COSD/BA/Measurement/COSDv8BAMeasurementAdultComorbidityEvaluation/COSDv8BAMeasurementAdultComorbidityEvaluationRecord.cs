using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv8BAMeasurementAdultComorbidityEvaluation;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 BA Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8BAMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8BAMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; init; }
    public string? AdultComorbidityEvaluation { get; init; }
    public DateOnly? MeasurementDate { get; init; }
}
