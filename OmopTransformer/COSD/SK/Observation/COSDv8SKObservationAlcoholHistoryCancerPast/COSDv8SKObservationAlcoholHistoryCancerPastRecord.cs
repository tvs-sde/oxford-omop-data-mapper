using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Observation.COSDv8SKObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 SK Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8SKObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv8SKObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
