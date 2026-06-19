using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungAdultComorbidityEvaluation;

[DataOrigin("COSD")]
[Description("CosdV8LungAdultComorbidityEvaluation")]
[SourceQuery("CosdV8LungAdultComorbidityEvaluation.xml")]
internal class CosdV8LungAdultComorbidityEvaluationRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? AdultComorbidityEvaluation { get; set; }
}
