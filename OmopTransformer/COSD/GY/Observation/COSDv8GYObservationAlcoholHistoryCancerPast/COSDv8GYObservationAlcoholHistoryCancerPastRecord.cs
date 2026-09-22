using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv8GYObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 GY Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8GYObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8GYObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
