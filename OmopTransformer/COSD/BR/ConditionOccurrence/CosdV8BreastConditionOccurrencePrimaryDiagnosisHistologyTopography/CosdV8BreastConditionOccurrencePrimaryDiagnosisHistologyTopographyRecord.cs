using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV8BreastConditionOccurrencePrimaryDiagnosisHistologyTopography;

[DataOrigin("COSD")]
[Description("Cosd V8 Breast Condition Occurrence Primary Diagnosis Histology Topography")]
[SourceQuery("CosdV8BreastConditionOccurrencePrimaryDiagnosisHistologyTopography.xml")]
internal class CosdV8BreastConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerHistology { get; set; }
    public string? CancerTopography { get; set; }
}
