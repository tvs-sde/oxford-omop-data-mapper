using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv8SAObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 SA Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8SAObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8SAObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
