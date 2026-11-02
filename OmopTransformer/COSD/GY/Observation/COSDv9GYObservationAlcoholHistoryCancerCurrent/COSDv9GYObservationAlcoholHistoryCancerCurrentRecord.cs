using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv9GYObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 GY Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9GYObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9GYObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
