using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv9URObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V9 UR Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv9URObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv9URObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
