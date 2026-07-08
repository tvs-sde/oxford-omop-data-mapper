using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv9HNObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 HN Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9HNObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9HNObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
