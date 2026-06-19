using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV8LungConditionOccurrencePrimaryDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Condition Occurrence Primary Diagnosis")]
[SourceQuery("CosdV8LungConditionOccurrencePrimaryDiagnosis.xml")]
internal class CosdV8LungConditionOccurrencePrimaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? CancerHistology { get; set; }
    public string? CancerTopography { get; set; }
    public string? CancerDiagnosis { get; set; }
}