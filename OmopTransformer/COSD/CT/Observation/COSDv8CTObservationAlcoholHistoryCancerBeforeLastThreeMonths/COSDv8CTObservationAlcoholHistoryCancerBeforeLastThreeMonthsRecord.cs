using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv8CTObservationAlcoholHistoryCancerBeforeLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 CT Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8CTObservationAlcoholHistoryCancerBeforeLastThreeMonths.xml")]
internal class COSDv8CTObservationAlcoholHistoryCancerBeforeLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerBeforeLastThreeMonths { get; set; }
}
