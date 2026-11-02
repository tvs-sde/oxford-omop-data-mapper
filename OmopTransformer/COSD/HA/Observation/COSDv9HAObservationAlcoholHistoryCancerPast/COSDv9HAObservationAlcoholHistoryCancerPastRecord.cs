using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv9HAObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 HA Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9HAObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9HAObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
