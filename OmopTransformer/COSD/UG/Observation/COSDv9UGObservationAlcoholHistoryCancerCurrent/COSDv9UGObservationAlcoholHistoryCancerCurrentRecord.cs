using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv9UGObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V9 UG Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv9UGObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv9UGObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
