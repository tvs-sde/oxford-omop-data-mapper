using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceProgressionIcd;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Progression ICD")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceProgressionIcd.xml")]
internal class CosdV9HaematologicalConditionOccurrenceProgressionIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? ProgressionIcd { get; set; }
}
