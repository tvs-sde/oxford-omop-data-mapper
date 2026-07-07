using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationAlcoholHistoryCancerInLastThreeMonths;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9CRObservationAlcoholHistoryCancerInLastThreeMonths.xml")]
internal class COSDv9CRObservationAlcoholHistoryCancerInLastThreeMonthsRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerInLastThreeMonths { get; set; }
}
