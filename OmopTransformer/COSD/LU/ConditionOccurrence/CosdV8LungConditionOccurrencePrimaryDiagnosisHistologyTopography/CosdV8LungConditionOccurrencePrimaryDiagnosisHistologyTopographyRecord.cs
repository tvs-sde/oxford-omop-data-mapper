using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV8LungConditionOccurrencePrimaryDiagnosisHistologyTopography;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Condition Occurrence Primary Diagnosis Histology Topography")]
[SourceQuery("CosdV8LungConditionOccurrencePrimaryDiagnosisHistologyTopography.xml")]
internal class CosdV8LungConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? CancerHistology { get; set; }
    public string? CancerTopography { get; set; }
    public string? CancerDiagnosis { get; set; }
}