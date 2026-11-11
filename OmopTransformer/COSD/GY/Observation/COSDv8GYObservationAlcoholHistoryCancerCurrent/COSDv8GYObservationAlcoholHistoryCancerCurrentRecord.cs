using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv8GYObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 GY Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8GYObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8GYObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
