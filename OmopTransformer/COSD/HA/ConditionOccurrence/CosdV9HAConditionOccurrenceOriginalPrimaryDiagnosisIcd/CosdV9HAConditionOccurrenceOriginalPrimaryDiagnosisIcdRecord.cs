using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.CosdV9HAConditionOccurrenceOriginalPrimaryDiagnosisIcd;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("CosdV9HAConditionOccurrenceOriginalPrimaryDiagnosisIcd.xml")]
internal class CosdV9HAConditionOccurrenceOriginalPrimaryDiagnosisIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
