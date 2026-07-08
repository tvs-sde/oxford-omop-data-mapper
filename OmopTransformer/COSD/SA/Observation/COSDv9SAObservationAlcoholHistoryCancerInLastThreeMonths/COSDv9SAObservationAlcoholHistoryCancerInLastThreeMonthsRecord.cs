using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv9SAObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 SA Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9SAObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv9SAObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
