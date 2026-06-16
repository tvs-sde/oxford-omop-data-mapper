using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Adult Comorbidity Evaluation")]
[SourceQuery("COSDv9HAMeasurementAdultComorbidityEvaluation.xml")]
internal class COSDv9HAMeasurementAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AdultComorbidityEvaluation27Score { get; set; }
}
