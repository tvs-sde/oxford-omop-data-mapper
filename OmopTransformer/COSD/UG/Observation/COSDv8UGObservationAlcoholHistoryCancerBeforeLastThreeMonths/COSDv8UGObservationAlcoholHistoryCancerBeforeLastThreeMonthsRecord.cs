using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv8UGObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 UG Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8UGObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv8UGObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
