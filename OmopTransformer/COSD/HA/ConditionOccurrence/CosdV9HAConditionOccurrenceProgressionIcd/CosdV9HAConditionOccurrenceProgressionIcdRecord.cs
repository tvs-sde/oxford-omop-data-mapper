using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.CosdV9HAConditionOccurrenceProgressionIcd;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Progression ICD")]
[SourceQuery("CosdV9HAConditionOccurrenceProgressionIcd.xml")]
internal class CosdV9HAConditionOccurrenceProgressionIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
