using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9CRObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9CRObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
