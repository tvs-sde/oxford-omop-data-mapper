using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.CosdV9HAConditionOccurrencePrimaryDiagnosisIcd;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("CosdV9HAConditionOccurrencePrimaryDiagnosisIcd.xml")]
internal class CosdV9HAConditionOccurrencePrimaryDiagnosisIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
