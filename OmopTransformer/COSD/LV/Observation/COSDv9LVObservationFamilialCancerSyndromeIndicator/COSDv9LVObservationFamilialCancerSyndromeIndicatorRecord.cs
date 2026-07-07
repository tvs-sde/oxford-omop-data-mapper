using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Observation.COSDv9LVObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 LV Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv9LVObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv9LVObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
