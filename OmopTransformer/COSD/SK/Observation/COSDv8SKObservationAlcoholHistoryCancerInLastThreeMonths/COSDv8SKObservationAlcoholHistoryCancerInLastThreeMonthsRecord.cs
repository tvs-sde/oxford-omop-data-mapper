using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv8SKObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 SK Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8SKObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv8SKObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
