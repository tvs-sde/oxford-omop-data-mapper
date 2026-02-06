using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CTYA.ConditionOccurrence.CosdV8CTYAConditionOccurrencePrimaryDiagnosisHistologyTopography;

[DataOrigin("COSD")]
[Description("Cosd V8 CTYA Condition Occurrence Primary Diagnosis Histology Topography")]
[SourceQuery("CosdV8CTYAConditionOccurrencePrimaryDiagnosisHistologyTopography.xml")]
internal class CosdV8CTYAConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord
{
    public string? NhsNumber { get; set; }
    public string? DiagnosisDate { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerHistology { get; set; }
    public string? CancerTopography { get; set; }
}
