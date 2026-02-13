using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrencePrimaryDiagnosisIcd;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Primary Diagnosis ICD")]
[SourceQuery("CosdV9HaematologicalConditionOccurrencePrimaryDiagnosisIcd.xml")]
internal class CosdV9HaematologicalConditionOccurrencePrimaryDiagnosisIcdRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PrimaryDiagnosisIcd { get; set; }
}
