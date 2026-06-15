using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementAdultComorbidityEvaluation;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8CTMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8CTMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; init; }
    public string? AdultComorbidityEvaluation { get; init; }
    public DateOnly? MeasurementDate { get; init; }
}
