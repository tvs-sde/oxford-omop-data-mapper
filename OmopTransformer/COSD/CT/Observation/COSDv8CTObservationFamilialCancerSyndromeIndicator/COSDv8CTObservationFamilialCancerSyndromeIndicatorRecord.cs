using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv8CTObservationFamilialCancerSyndromeIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 CT Observation Familial Cancer Syndrome Indicator")]
[SourceQuery("COSDv8CTObservationFamilialCancerSyndromeIndicator.xml")]
internal class COSDv8CTObservationFamilialCancerSyndromeIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? FamilialCancerSyndromeIndicator { get; set; }
}
