using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 CT Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9CTObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9CTObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
