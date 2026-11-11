using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv8SAObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 SA Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8SAObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8SAObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
