using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrencePrimaryDiagnosisHistologyTopography;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Condition Occurrence Primary Diagnosis Histology Topography")]
[SourceQuery("CosdV9BreastConditionOccurrencePrimaryDiagnosisHistologyTopography.xml")]
internal class CosdV9BreastConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerHistology { get; set; }
    public string? CancerTopography { get; set; }
}
