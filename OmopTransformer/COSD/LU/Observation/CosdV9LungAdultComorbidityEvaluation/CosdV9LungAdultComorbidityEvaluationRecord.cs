using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV9LungAdultComorbidityEvaluation")]
[SourceQuery("CosdV9LungAdultComorbidityEvaluation.xml")]
internal class CosdV9LungAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
