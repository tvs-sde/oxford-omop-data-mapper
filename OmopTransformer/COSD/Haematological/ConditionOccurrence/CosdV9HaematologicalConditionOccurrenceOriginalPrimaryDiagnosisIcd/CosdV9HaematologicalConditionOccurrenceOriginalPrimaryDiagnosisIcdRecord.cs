using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceOriginalPrimaryDiagnosisIcd;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Original Primary Diagnosis ICD")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceOriginalPrimaryDiagnosisIcd.xml")]
internal class CosdV9HaematologicalConditionOccurrenceOriginalPrimaryDiagnosisIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? OriginalPrimaryDiagnosisIcd { get; set; }
}
