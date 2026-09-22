using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv9SKObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 SK Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9SKObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv9SKObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
