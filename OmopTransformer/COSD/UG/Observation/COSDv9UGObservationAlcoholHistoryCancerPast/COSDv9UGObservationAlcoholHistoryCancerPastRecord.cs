using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv9UGObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 UG Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9UGObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv9UGObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
