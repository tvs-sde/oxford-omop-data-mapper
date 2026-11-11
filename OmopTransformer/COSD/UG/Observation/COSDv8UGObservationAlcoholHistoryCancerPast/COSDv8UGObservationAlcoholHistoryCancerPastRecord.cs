using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv8UGObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 UG Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8UGObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8UGObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
