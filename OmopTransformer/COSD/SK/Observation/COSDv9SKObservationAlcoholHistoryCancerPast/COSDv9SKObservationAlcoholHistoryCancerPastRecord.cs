using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv9SKObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 SK Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9SKObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9SKObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
