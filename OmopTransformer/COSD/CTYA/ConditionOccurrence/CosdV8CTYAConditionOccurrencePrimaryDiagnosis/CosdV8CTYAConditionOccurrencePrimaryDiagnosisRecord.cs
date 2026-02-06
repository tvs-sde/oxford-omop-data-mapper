using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CTYA.ConditionOccurrence.CosdV8CTYAConditionOccurrencePrimaryDiagnosis;

[DataOrigin("COSD")]
[Description("Cosd V8 CTYA Condition Occurrence Primary Diagnosis")]
[SourceQuery("CosdV8CTYAConditionOccurrencePrimaryDiagnosis.xml")]
internal class CosdV8CTYAConditionOccurrencePrimaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerDiagnosis { get; set; }
}
