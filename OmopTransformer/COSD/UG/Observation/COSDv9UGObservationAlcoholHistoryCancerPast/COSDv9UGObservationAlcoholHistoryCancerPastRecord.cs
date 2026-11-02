using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv9UGObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 UG Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9UGObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9UGObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
