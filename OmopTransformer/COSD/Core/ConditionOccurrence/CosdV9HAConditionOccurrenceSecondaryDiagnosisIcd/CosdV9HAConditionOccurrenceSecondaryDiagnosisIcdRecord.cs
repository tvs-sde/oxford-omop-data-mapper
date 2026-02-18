using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceSecondaryDiagnosisIcd;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("COSDv9HAConditionOccurrenceSecondaryDiagnosisIcd.xml")]
internal class CosdV9HAConditionOccurrenceSecondaryDiagnosisIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
