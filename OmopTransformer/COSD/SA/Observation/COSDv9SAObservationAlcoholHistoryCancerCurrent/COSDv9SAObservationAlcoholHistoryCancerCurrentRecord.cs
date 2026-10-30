using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv9SAObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 SA Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9SAObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9SAObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
