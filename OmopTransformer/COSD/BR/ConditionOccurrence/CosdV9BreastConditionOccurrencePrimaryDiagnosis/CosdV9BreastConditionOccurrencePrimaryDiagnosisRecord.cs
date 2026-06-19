using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrencePrimaryDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Condition Occurrence Primary Diagnosis")]
[SourceQuery("CosdV9BreastConditionOccurrencePrimaryDiagnosis.xml")]
internal class CosdV9BreastConditionOccurrencePrimaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerDiagnosis { get; set; }
}
