using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv9HNObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 HN Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9HNObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9HNObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
