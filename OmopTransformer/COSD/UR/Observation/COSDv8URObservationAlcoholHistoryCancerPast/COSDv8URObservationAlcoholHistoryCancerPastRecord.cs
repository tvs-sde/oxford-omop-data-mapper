using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv8URObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 UR Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8URObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8URObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
