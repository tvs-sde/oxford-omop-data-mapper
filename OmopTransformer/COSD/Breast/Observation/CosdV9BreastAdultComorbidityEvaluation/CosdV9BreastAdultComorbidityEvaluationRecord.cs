using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Adult Comorbidity Evaluation")]
[SourceQuery("CosdV9BreastAdultComorbidityEvaluation.xml")]
internal class CosdV9BreastAdultComorbidityEvaluationRecord
{
    public string? AdultComorbidityEvaluation { get; set; }
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
}
