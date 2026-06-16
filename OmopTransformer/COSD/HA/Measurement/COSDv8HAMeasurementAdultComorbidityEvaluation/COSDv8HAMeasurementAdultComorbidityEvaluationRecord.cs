using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv8HAMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv8HAMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
