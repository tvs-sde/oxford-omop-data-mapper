using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV8ConditionOccurrencePrimaryDiagnosis;

[DataOrigin("COSD")]
[Description("Cosd V8 Condition Occurrence Primary Diagnosis")]
[SourceQuery("CosdV8ConditionOccurrencePrimaryDiagnosis.xml")]
internal class CosdV8ConditionOccurrencePrimaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerDiagnosis { get; set; }
}