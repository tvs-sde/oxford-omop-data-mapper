using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv8SKObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 SK Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8SKObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8SKObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
