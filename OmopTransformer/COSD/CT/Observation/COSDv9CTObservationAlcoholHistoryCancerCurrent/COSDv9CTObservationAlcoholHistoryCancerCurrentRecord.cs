using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 CT Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9CTObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9CTObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
