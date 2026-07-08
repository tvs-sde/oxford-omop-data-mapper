using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv8SAObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 SA Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8SAObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv8SAObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
