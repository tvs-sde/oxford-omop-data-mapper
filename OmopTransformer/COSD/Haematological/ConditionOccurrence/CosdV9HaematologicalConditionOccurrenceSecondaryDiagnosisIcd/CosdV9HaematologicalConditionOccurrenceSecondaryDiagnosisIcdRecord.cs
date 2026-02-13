using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceSecondaryDiagnosisIcd;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Secondary Diagnosis ICD")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceSecondaryDiagnosisIcd.xml")]
internal class CosdV9HaematologicalConditionOccurrenceSecondaryDiagnosisIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosisIcd { get; set; }
}
