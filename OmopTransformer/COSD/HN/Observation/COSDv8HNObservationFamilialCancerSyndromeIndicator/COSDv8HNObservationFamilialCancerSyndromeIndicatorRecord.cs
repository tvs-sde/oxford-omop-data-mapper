using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv8HNObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 HN Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8HNObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8HNObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
