using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9CRObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9CRObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
