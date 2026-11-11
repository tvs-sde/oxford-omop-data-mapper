using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv8CRObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 CR Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8CRObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8CRObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
