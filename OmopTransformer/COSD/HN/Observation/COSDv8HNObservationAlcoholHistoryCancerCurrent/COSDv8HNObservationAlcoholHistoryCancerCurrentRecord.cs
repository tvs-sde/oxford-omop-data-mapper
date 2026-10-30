using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv8HNObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 HN Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8HNObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8HNObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
