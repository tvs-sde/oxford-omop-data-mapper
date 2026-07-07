using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv8CTObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V8 CT Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8CTObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv8CTObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
