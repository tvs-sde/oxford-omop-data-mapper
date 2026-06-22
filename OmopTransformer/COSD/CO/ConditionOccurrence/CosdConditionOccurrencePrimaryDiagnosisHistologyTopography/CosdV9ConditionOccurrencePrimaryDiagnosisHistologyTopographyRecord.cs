using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrencePrimaryDiagnosisHistologyTopography;

[DataOrigin("COSD")]
[Description("COSD V9 Condition Occurrence Primary Diagnosis Histology Topography")]
[SourceQuery("CosdV9ConditionOccurrencePrimaryDiagnosisHistologyTopography.xml")]
internal class CosdV9ConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? BasisOfDiagnosisCancer { get; set; }
    public string? CancerHistology { get; set; }
    public string? CancerTopography { get; set; }
}