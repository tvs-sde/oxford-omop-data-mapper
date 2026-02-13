using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceMorphologySnomedDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 Haematological Condition Occurrence Morphology SNOMED Diagnosis")]
[SourceQuery("CosdV9HaematologicalConditionOccurrenceMorphologySnomedDiagnosis.xml")]
internal class CosdV9HaematologicalConditionOccurrenceMorphologySnomedDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologySnomedDiagnosis { get; set; }
}
