using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv9UGObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 UG Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9UGObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv9UGObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
