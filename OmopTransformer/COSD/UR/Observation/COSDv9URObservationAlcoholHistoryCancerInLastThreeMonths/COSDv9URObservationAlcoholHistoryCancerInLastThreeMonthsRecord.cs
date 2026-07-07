using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv9URObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 UR Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9URObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv9URObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
