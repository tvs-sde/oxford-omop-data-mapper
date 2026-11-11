using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv9HNObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 HN Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9HNObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9HNObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
