using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv8CRObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 CR Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8CRObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8CRObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
