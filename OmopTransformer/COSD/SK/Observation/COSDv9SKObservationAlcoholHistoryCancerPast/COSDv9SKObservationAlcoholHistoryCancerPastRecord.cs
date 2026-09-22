using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv9SKObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 SK Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9SKObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv9SKObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
