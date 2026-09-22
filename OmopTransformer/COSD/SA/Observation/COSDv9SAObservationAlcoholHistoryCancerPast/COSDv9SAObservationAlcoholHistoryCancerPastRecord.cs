using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv9SAObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 SA Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9SAObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9SAObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
