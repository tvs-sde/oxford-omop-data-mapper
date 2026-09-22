using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv8CTObservationAlcoholHistoryCancerPast;

[DataOrigin("COSD")]
[Description("COSD V8 CT Observation Alcohol History Cancer Before Last Three Months")]
[SourceQuery("COSDv8CTObservationAlcoholHistoryCancerPast.xml")]
internal class COSDv8CTObservationAlcoholHistoryCancerPastRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerPast { get; set; }
}
