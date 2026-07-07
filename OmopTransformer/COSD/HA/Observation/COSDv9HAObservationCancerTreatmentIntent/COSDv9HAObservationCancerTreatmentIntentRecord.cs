using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv9HAObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V9 HA Observation Cancer Treatment Intent")]
[SourceQuery("COSDv9HAObservationCancerTreatmentIntent.xml")]
internal class COSDv9HAObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
