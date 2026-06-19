using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV8ConditionOccurrencePrimaryDiagnosisHistologyTopography;

[DataOrigin("COSD")]
[Description("Cosd V8 Condition Occurrence Primary Diagnosis Histology Topography")]
[SourceQuery("CosdV8ConditionOccurrencePrimaryDiagnosisHistologyTopography.xml")]
internal class CosdV8ConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerHistology { get; set; }
    public string? CancerTopography { get; set; }
}