using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv8UGObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 UG Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8UGObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8UGObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
