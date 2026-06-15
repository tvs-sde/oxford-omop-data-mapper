using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementAdultComorbidityEvaluation;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8CRMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8CRMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; init; }
    public string? AdultComorbidityEvaluation { get; init; }
    public DateOnly? MeasurementDate { get; init; }
}
