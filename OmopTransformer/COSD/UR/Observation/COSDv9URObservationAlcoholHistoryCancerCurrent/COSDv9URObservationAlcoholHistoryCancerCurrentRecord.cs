using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv9URObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 UR Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9URObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9URObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
