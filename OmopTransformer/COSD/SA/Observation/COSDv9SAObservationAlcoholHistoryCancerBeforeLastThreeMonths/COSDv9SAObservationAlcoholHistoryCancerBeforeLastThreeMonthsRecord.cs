using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv9SAObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 SA Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9SAObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv9SAObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
