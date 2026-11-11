using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv8HNObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 HN Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8HNObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8HNObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
