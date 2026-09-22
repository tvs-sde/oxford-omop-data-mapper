using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv8CTObservationAlcoholHistoryCancerCurrent;

[DataOrigin("COSD")]
[Description("COSD V8 CT Observation Alcohol History Cancer In Last Three Months")]
[SourceQuery("COSDv8CTObservationAlcoholHistoryCancerCurrent.xml")]
internal class COSDv8CTObservationAlcoholHistoryCancerCurrentRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AlcoholHistoryCancerCurrent { get; set; }
}
