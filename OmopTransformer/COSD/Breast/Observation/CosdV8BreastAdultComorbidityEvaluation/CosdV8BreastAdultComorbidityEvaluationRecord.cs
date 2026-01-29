using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV8BreastAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Adult Comorbidity Evaluation")]
[SourceQuery("CosdV8BreastAdultComorbidityEvaluation.xml")]
internal class CosdV8BreastAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
