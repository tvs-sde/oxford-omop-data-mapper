using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 HA Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8HAObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8HAObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
