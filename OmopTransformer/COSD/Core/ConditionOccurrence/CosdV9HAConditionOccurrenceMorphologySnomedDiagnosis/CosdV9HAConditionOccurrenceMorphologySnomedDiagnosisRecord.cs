using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceMorphologySnomedDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 HA Condition Occurrence Morphology SNOMED Diagnosis")]
[SourceQuery("COSDv9HAConditionOccurrenceMorphologySnomedDiagnosis.xml")]
internal class CosdV9HAConditionOccurrenceMorphologySnomedDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MorphologySnomedDiagnosis { get; set; }
}
