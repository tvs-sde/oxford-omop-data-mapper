using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrenceSecondaryDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Condition Occurrence Secondary Diagnosis")]
[SourceQuery("CosdV9BreastConditionOccurrenceSecondaryDiagnosis.xml")]
internal class CosdV9BreastConditionOccurrenceSecondaryDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SecondaryDiagnosis { get; set; }
}
