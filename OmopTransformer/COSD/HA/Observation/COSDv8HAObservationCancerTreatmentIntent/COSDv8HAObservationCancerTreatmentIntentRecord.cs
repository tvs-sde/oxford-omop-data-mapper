using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V8 HA Observation Cancer Treatment Intent")]
[SourceQuery("COSDv8HAObservationCancerTreatmentIntent.xml")]
internal class COSDv8HAObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
