using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv9URObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 UR Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9URObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv9URObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
