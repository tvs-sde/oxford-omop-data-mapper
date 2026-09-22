using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv8SKObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 SK Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8SKObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8SKObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
