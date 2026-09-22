using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 HA Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8HAObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8HAObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
