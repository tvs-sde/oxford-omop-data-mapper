using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv9GYObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 GY Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9GYObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9GYObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
