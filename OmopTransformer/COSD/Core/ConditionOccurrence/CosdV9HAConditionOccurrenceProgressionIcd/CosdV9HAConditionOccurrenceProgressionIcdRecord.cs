using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceProgressionIcd;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Progression ICD")]
[SourceQuery("COSDv9HAConditionOccurrenceProgressionIcd.xml")]
internal class CosdV9HAConditionOccurrenceProgressionIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
