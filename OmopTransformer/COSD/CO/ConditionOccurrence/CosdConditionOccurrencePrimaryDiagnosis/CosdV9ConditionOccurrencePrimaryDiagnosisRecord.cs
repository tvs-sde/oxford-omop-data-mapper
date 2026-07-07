using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrencePrimaryDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 Condition Occurrence Primary Diagnosis")]
[SourceQuery("CosdV9ConditionOccurrencePrimaryDiagnosis.xml")]
internal class CosdV9ConditionOccurrencePrimaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerDiagnosis { get; set; }
}