using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV8BreastConditionOccurrencePrimaryDiagnosis;

[DataOrigin("COSD")]
[Description("Cosd V8 Breast Condition Occurrence Primary Diagnosis")]
[SourceQuery("CosdV8BreastConditionOccurrencePrimaryDiagnosis.xml")]
internal class CosdV8BreastConditionOccurrencePrimaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerDiagnosis { get; set; }
}
