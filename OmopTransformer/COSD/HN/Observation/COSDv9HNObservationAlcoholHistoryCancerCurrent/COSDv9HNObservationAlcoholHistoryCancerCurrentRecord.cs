using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv9HNObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 HN Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9HNObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv9HNObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
