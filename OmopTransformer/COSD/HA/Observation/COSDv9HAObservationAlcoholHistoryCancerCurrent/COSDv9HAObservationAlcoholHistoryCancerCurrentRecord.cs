using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv9HAObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 HA Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9HAObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9HAObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
