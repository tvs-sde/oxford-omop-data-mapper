using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv9SKObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 SK Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9SKObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9SKObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
