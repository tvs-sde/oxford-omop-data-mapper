using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv8GYObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 GY Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8GYObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv8GYObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
