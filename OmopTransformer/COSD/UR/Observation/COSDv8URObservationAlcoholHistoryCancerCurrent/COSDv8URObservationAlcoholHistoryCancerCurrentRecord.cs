using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv8URObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 UR Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8URObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8URObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
