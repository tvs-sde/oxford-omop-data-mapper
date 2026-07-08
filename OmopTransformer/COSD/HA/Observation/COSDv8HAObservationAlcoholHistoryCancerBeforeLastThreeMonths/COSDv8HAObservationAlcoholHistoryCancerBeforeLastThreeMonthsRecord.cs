using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 HA Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8HAObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv8HAObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
