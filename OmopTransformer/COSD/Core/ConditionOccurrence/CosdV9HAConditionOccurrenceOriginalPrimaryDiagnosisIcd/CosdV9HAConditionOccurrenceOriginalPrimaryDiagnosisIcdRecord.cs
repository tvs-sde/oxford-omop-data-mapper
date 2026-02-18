using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceOriginalPrimaryDiagnosisIcd;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("COSDv9HAConditionOccurrenceOriginalPrimaryDiagnosisIcd.xml")]
internal class CosdV9HAConditionOccurrenceOriginalPrimaryDiagnosisIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
